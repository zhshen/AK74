﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MCS.Library.Core {
    using System;
    using System.Reflection;
    
    
    /// <summary>
    ///    A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Resource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        internal Resource() {
        }
        
        /// <summary>
        ///    Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("MCS.Library.Core.Resource", typeof(Resource).GetTypeInfo().Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///    Overrides the current thread's CurrentUICulture property for all
        ///    resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to 不能找到名称为{0}的配置集合元素.
        /// </summary>
        public static string CanNotFindNamedConfigElement {
            get {
                return ResourceManager.GetString("CanNotFindNamedConfigElement", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to 不能在Xml节点{0}下找到{1}.
        /// </summary>
        public static string CanNotFindXmlNode {
            get {
                return ResourceManager.GetString("CanNotFindXmlNode", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to 不能在配置文件中找到配置节&quot;{0}&quot;.
        /// </summary>
        public static string CanNotFoundConfigSection {
            get {
                return ResourceManager.GetString("CanNotFoundConfigSection", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to 不能在配置文件中找到配置节&quot;{0}&quot;的详细定义部分.
        /// </summary>
        public static string CanNotFoundConfigSectionElement {
            get {
                return ResourceManager.GetString("CanNotFoundConfigSectionElement", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to 集合类是只读的，不能执行该操作.
        /// </summary>
        public static string CollectionIsReadOnly {
            get {
                return ResourceManager.GetString("CollectionIsReadOnly", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to Xml节点{0}转换到属性{1}出错，{2}.
        /// </summary>
        public static string ConvertXmlNodeToPropertyError {
            get {
                return ResourceManager.GetString("ConvertXmlNodeToPropertyError", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to Timestamp: {timestamp}.
        /// </summary>
        public static string DefaultTextFormat {
            get {
                return ResourceManager.GetString("DefaultTextFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to Cache项{0}失效了，失效的依赖条件类型是{1}.
        /// </summary>
        public static string DependencyChanged {
            get {
                return ResourceManager.GetString("DependencyChanged", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to 在集合中添加对象类型{0}时，Key属性值&quot;{1}&quot;重复.
        /// </summary>
        public static string DuplicateDescriptorKey {
            get {
                return ResourceManager.GetString("DuplicateDescriptorKey", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to 已添加了具有相同键的项: {0}.
        /// </summary>
        public static string DuplicateKey {
            get {
                return ResourceManager.GetString("DuplicateKey", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to 应用&apos;{0}&apos; 定义了相互冲突的路径&apos;{1}&apos; 和  &apos;{2}&apos;.
        /// </summary>
        public static string ExceptionConflictPathDefinition {
            get {
                return ResourceManager.GetString("ExceptionConflictPathDefinition", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to The value can not be null or an empty string..
        /// </summary>
        public static string ExceptionNullOrEmptyString {
            get {
                return ResourceManager.GetString("ExceptionNullOrEmptyString", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to The formatter type &apos;{0}&apos; of &apos;{1}&apos;  is invalid..
        /// </summary>
        public static string ExceptionSerializationFormatterType {
            get {
                return ResourceManager.GetString("ExceptionSerializationFormatterType", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to 文件&quot;{0}&quot;不存在.
        /// </summary>
        public static string FileNotFound {
            get {
                return ResourceManager.GetString("FileNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to Meta中配置的全局配置文件&quot;{0}&quot;不存在.
        /// </summary>
        public static string GlobalFileNotFound {
            get {
                return ResourceManager.GetString("GlobalFileNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to 初始化类属性失败。错误信息：{0}.
        /// </summary>
        public static string InitialPropertyError {
            get {
                return ResourceManager.GetString("InitialPropertyError", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to 成员{0}，对象映射时不支持的成员类型{1}.
        /// </summary>
        public static string InvalidMemberInfoType {
            get {
                return ResourceManager.GetString("InvalidMemberInfoType", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to Meta文件&quot;{0}&quot;不存在.
        /// </summary>
        public static string MetaFileNotFound {
            get {
                return ResourceManager.GetString("MetaFileNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to &lt;Error: property {0} not found&gt;.
        /// </summary>
        public static string ReflectedPropertyTokenNotFound {
            get {
                return ResourceManager.GetString("ReflectedPropertyTokenNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to 字符串参数{0}不能为Null或空串.
        /// </summary>
        public static string StringParamCanNotBeNullOrEmpty {
            get {
                return ResourceManager.GetString("StringParamCanNotBeNullOrEmpty", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to 不能加载类型{0}.
        /// </summary>
        public static string TypeLoadException {
            get {
                return ResourceManager.GetString("TypeLoadException", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to 类型{0}必须是枚举类型.
        /// </summary>
        public static string TypeMustBeEnum {
            get {
                return ResourceManager.GetString("TypeMustBeEnum", resourceCulture);
            }
        }
    }
}