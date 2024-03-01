# 开发规范

## 1. 命名规范

为了保持代码的一致性和易读性，应该遵循以下命名规范：
### 大驼峰式（CamelCase or PascalCase）
* 类，例如：UserService
* 接口，以大写字母"I"开头，例如：ILogger。
* 属性，例如：UserName，Password。
* 方法和函数，例如：GetUser，CreateOrder。  
* 数据库表名称与表字段，例如：DorBuilding，SysMenus，SysRoles。

### 大蛇式 (SNAKE_CASE)
* 常量，例如：MAX_LENGTH，MIN_VALUE。

### 小驼峰式（camelCase）
* 变量和参数，例如：userName，productId。

### 下划线开头
* 类私有变量，例如：_password，_userRepository


## 2. 编码规范

为了保持代码的可读性和易于维护性，应该遵循以下编码规范：

* 使用有意义的命名来提高代码的可读性。
* 避免使用魔法数字和硬编码的值，使用常量或枚举来代替。
* 对于长方法和函数，应该考虑拆分成小的方法和函数，避免出现大块的代码。
* 在代码中添加注释，解释方法和函数的作用和参数的含义。
* 对于公共方法和函数，应该添加文档注释，让其他开发人员知道如何正确地使用它们。


## 3. 异常处理规范

为了保持代码的健壮性和可靠性，应该遵循以下异常处理规范：

* 使用try-catch语句处理可能会引发异常的代码。
* 在catch块中添加日志记录和错误处理代码，避免异常的出现对系统的影响。
* 在catch块中抛出自定义异常，以便更好地描述异常的类型和原因。
* 不要在catch块中忽略异常，以防止错误的代码逻辑。
* 如果要抛出原有异常，直接使用throw，切勿使用throw ex。


# git版本控制


## 1. 分支管理规范

在Git中，分支是非常重要的概念，它可以让你在开发过程中保持代码的稳定性和可维护性。以下是一些关于分支管理的规范：

* 主分支应该是稳定的，只包含已发布的代码，例如master或main分支。
* 开发人员应该从主分支创建新的分支，例如feature/xxx或bugfix/xxx分支。
* 每个分支应该只包含一个功能或修复一个问题，避免在同一个分支上进行多个任务的操作。
* 在分支上进行开发之前，应该先从主分支进行拉取，并进行本地合并和测试。

## 2. 提交规范

Git的提交是非常重要的，它可以让你追踪代码的更改历史，并且方便代码审查。以下是一些关于提交规范：

* 提交应该包含有意义的信息，例如修复了哪个问题或增加了哪个功能。
* 提交信息应该简洁明了，不要过于冗长。
* 在提交时，应该遵循一致的格式和风格，以下是常用的格式，例如"fix: xx字段缺失"
    * wip: 开发中
    * feat：提交新功能  
    * fix：修复了bug  
    * docs：只修改了文档  
    * style：调整代码格式，未修改代码逻辑（比如修改空格、格式化、缺少分号等）  
    * refactor：代码重构，既没修复bug也没有添加新功能  
    * perf：性能优化，提高性能的代码更改  
    * test：添加或修改代码测试  
    * chore：对构建流程或辅助工具和依赖库（如文档生成等）的更改  


## 3. 合并规范

合并是Git中另一个重要的概念，它可以让你将不同的分支合并为一个更完整的代码库。以下是一些关于合并规范：

* 在进行合并之前，应该先从主分支进行拉取，确保本地和远程分支的代码保持一致。
* 在进行合并时，应该进行代码审查，确保合并后的代码是稳定和可维护的。
* 如果合并产生了冲突，应该进行适当的解决，避免在代码库中留下未解决的冲突。