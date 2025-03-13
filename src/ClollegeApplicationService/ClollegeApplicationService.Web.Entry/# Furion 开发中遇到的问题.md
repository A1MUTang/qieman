# Microsoft.CodeAnalysis.CSharp 存在版本冲突

## 错误信息

 ~ C#
    dotnet build
        C:\Users\sam\source\repos\qieman\src\ClollegeApplicationService\ClollegeApplicationService.Web.Entry\ClollegeApplicationService.Web.Entry.csproj : error NU1107:  
        Microsoft.CodeAnalysis.CSharp 中检测到版本冲突。直接安装/引用 Microsoft.CodeAnalysis.CSharp 4.8.0 到项目 ClollegeApplicationService.Web.Entry 可解决此问题。 
        ClollegeApplicationService.Web.Entry -> ClollegeApplicationService.Web.Core -> ClollegeApplicationService.Application -> ClollegeApplicationService.Core -> Fur
        ion 4.9.7.23 -> Furion.Extras.DependencyModel.CodeAnalysis 4.9.7.23 -> Microsoft.CodeAnalysis.CSharp (>= 4.8.0) 
        ClollegeApplicationService.Web.Entry -> Microsoft.EntityFrameworkCore.Tools 8.0.11 -> Microsoft.EntityFrameworkCore.Design 8.0.11 -> Microsoft.CodeAnalysis.CSh
        arp.Workspaces 4.5.0 -> Microsoft.CodeAnalysis.CSharp (= 4.5.0).
    ~

## 问题描述

 这里描述具体遇到的问题。

## 解决方案

 这里描述解决该问题的方案。
