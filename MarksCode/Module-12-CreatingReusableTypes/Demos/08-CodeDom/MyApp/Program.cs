using Microsoft.CSharp;
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var unit = new CodeCompileUnit();

            var dynamicNamespace = new CodeNamespace("Wow");
            unit.Namespaces.Add(dynamicNamespace);

            dynamicNamespace.Imports.Add(new CodeNamespaceImport("System"));

            //**** Create the containing class ****
            var programType = new CodeTypeDeclaration("Program");
            dynamicNamespace.Types.Add(programType);

            //**** Create a method, set it as the application entry point ****
            var mainMethod = new CodeEntryPointMethod();
            programType.Members.Add(mainMethod);


            var expression = new CodeMethodInvokeExpression(
                                new CodeTypeReferenceExpression("Console"),
                                "WriteLine",
                                new CodePrimitiveExpression("Adding two numbers..!!"));
            mainMethod.Statements.Add(expression);

            var expression2 = new CodeMethodInvokeExpression(
                    new CodeTypeReferenceExpression("Console"),
                    "WriteLine",
                    new CodeSnippetExpression("\"3 + 4={0}\",Add(3,4)"));
            mainMethod.Statements.Add(expression2);

            var expression3 = new CodeMethodInvokeExpression(
                   new CodeTypeReferenceExpression("Console"),
                   "ReadLine");
            mainMethod.Statements.Add(expression3);



            //**** Create a method that accepts 2 parameters and returns a value ****
            var addFunction = new CodeMemberMethod();
            addFunction.Name = "Add";
            addFunction.Parameters.Add(new CodeParameterDeclarationExpression(new CodeTypeReference("System.Int32"), "x"));
            addFunction.Parameters.Add(new CodeParameterDeclarationExpression(new CodeTypeReference("System.Int32"), "y"));
            addFunction.Attributes = MemberAttributes.Static;
            addFunction.ReturnType = new CodeTypeReference("System.Int32");

            programType.Members.Add(addFunction);
            var functionBody = new CodeSnippetExpression("return x + y");

            addFunction.Statements.Add(functionBody);

            //**** Generate the CSharp ****
            var provider = new CSharpCodeProvider();

            var fileName = @"C:\temp\programXYZ.cs";
            var stream = new StreamWriter(fileName);

            var textWriter = new IndentedTextWriter(stream);

            var options = new CodeGeneratorOptions();
            options.BlankLinesBetweenMembers = true;

            provider.GenerateCodeFromCompileUnit(unit, textWriter, options);

            textWriter.Close();
            stream.Close();

            //**** Attempt to compile the CSharp ****
            var compilerSettings = new CompilerParameters();
            compilerSettings.ReferencedAssemblies.Add("System.dll");
            compilerSettings.GenerateExecutable = true;
            compilerSettings.OutputAssembly = @"C:\temp\ProgramXYZ.exe";

            var sourceCodeFileName = @"C:\temp\programXYZ.cs";
            var compilationResults = provider.CompileAssemblyFromFile(compilerSettings, sourceCodeFileName);

            foreach (var item in compilationResults.Errors)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine("OK, Done. press any key to end.");
            Console.ReadLine();
     
        }
    }
}
