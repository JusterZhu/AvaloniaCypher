using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AvaloniaApplication2;
/// <summary>
/// 兼具属性通知和数据验证功能的基类
/// 继承自BindableBase（通常实现INotifyPropertyChanged接口，用于属性变更通知）
/// 实现INotifyDataErrorInfo接口，用于支持数据验证错误的通知机制
/// </summary>
public class ValidateBindbleBase : ObservableObject, INotifyDataErrorInfo
{
    /// <summary>
    /// 存储属性验证错误的字典
    /// 键：属性名称（string）
    /// 值：该属性对应的所有错误信息集合（ICollection<string>）
    /// </summary>
    private readonly Dictionary<string, ICollection<string>> _validationErrors = new();

    /// <summary>
    /// INotifyDataErrorInfo接口定义的事件
    /// 当属性的验证错误发生变化（新增/移除错误）时触发，用于通知UI更新错误显示
    /// </summary>
    public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

    /// <summary>
    /// INotifyDataErrorInfo接口定义的属性
    /// 指示当前是否存在任何验证错误（只要错误字典中有数据，就返回true）
    /// </summary>
    public bool HasErrors => _validationErrors.Count > 0;

    /// <summary>
    /// INotifyDataErrorInfo接口定义的方法
    /// 获取指定属性的所有验证错误信息
    /// </summary>
    /// <param name="propertyName">需要获取错误的属性名称（null则返回所有属性的错误）</param>
    /// <returns>指定属性的错误信息集合，若不存在则返回null</returns>
    public IEnumerable GetErrors(string propertyName)
    {
        // 若字典中不包含该属性的错误，返回null
        if (!_validationErrors.ContainsKey(propertyName))
            return null;
        
        // 返回该属性对应的错误信息集合
        return _validationErrors[propertyName];
    }

    /// <summary>
    /// 获取第一个非空的验证错误信息（用于快速显示一个错误提示）
    /// </summary>
    /// <returns>第一个错误信息，若没有错误则返回null</returns>
    public string? GetError() => 
        // 从错误字典的所有值中，取第一个包含错误信息的集合，再返回该集合的第一个错误
        _validationErrors.Values.FirstOrDefault(errors => errors.Count > 0)?.FirstOrDefault();

    /// <summary>
    /// 验证指定属性的值（核心验证方法）
    /// 使用System.ComponentModel.DataAnnotations中的验证机制（如特性验证：[Required]、[MaxLength]等）
    /// </summary>
    /// <typeparam name="T">属性值的类型</typeparam>
    /// <param name="propertyName">需要验证的属性名称</param>
    /// <param name="value">需要验证的属性值</param>
    protected void ValidateProperty<T>(string propertyName, T value)
    {
        // 若值为null，暂不验证（可根据需求调整，例如允许null但需要其他验证）
        if (value == null) return;

        // 创建验证上下文：指定验证的对象实例（this）和需要验证的成员名称（propertyName）
        var context = new ValidationContext(this) { MemberName = propertyName };
        // 存储验证结果的集合
        var validationResults = new List<ValidationResult>();

        // 执行属性验证：使用Validator.TryValidateProperty进行数据注解验证
        // 验证结果会存入validationResults集合
        Validator.TryValidateProperty(value, context, validationResults);

        // 若该属性之前有错误记录，先移除旧错误（避免错误信息残留）
        if (_validationErrors.ContainsKey(propertyName))
        {
            _validationErrors.Remove(propertyName);
        }

        // 处理新的验证结果（更新错误字典并触发事件）
        HandleValidationResults(propertyName, validationResults);
    }

    /// <summary>
    /// 处理验证结果的私有方法
    /// 将验证错误存入字典，并在有错误时触发ErrorsChanged事件
    /// </summary>
    /// <param name="propertyName">属性名称</param>
    /// <param name="validationResults">验证结果集合（包含错误信息）</param>
    private void HandleValidationResults(string propertyName, ICollection<ValidationResult> validationResults)
    {
        // 若没有验证错误，直接返回（无需处理）
        if (validationResults.Count == 0)
            return;

        // 为当前属性添加错误集合（初始化一个空列表）
        _validationErrors.Add(propertyName, new List<string>());
        // 遍历验证结果，将错误信息添加到字典中
        foreach (var validationResult in validationResults)
        {
            _validationErrors[propertyName].Add(validationResult?.ErrorMessage);
        }

        // 触发ErrorsChanged事件，通知外部（如UI）该属性的错误状态已变更
        ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
    }
}