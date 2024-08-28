﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by Reqnroll (https://www.reqnroll.net/).
//      Reqnroll Version:2.0.0.0
//      Reqnroll Generator Version:2.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace ValueStringBuilderFeatures
{
    using Reqnroll;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Reqnroll", "2.0.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class AppendContentIntoAValueStringBuilderFeature
    {
        
        private static global::Reqnroll.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
        private static string[] featureTags = ((string[])(null));
        
#line 1 "Append.feature"
#line hidden
        
        public virtual Microsoft.VisualStudio.TestTools.UnitTesting.TestContext TestContext
        {
            get
            {
                return this._testContext;
            }
            set
            {
                this._testContext = value;
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static async System.Threading.Tasks.Task FeatureSetupAsync(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = global::Reqnroll.TestRunnerManager.GetTestRunnerForAssembly(null, System.Threading.Thread.CurrentThread.ManagedThreadId.ToString());
            global::Reqnroll.FeatureInfo featureInfo = new global::Reqnroll.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "ValueStringBuilderFeatures", "Append content into a ValueStringBuilder", null, global::Reqnroll.ProgrammingLanguage.CSharp, featureTags);
            await testRunner.OnFeatureStartAsync(featureInfo);
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute(Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupBehavior.EndOfClass)]
        public static async System.Threading.Tasks.Task FeatureTearDownAsync()
        {
            await testRunner.OnFeatureEndAsync();
            testRunner = null;
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestInitializeAttribute()]
        public async System.Threading.Tasks.Task TestInitializeAsync()
        {
            if (((testRunner.FeatureContext != null) 
                        && (testRunner.FeatureContext.FeatureInfo.Title != "Append content into a ValueStringBuilder")))
            {
                await global::ValueStringBuilderFeatures.AppendContentIntoAValueStringBuilderFeature.FeatureSetupAsync(null);
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCleanupAttribute()]
        public async System.Threading.Tasks.Task TestTearDownAsync()
        {
            await testRunner.OnScenarioEndAsync();
        }
        
        public void ScenarioInitialize(global::Reqnroll.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Microsoft.VisualStudio.TestTools.UnitTesting.TestContext>(_testContext);
        }
        
        public async System.Threading.Tasks.Task ScenarioStartAsync()
        {
            await testRunner.OnScenarioStartAsync();
        }
        
        public async System.Threading.Tasks.Task ScenarioCleanupAsync()
        {
            await testRunner.CollectScenarioErrorsAsync();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Fits in available space")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Append content into a ValueStringBuilder")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DataRowAttribute("Span", "11", "Hello", "World!", null)]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DataRowAttribute("Capacity", "11", "Hello", "World!", null)]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DataRowAttribute("Span", "20", "Hello", "World!", null)]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DataRowAttribute("Capacity", "20", "Hello", "World!", null)]
        public async System.Threading.Tasks.Task FitsInAvailableSpace(string initializationType, string initialLength, string firstValue, string secondValue, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("InitializationType", initializationType);
            argumentsOfScenario.Add("InitialLength", initialLength);
            argumentsOfScenario.Add("FirstValue", firstValue);
            argumentsOfScenario.Add("SecondValue", secondValue);
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("Fits in available space", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 3
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 4
    await testRunner.GivenAsync(string.Format("a ValueStringBuilder initialized with \'{0}\' of length {1}", initializationType, initialLength), ((string)(null)), ((global::Reqnroll.Table)(null)), "Given ");
#line hidden
#line 5
 await testRunner.AndAsync(string.Format("I append \'{0}\' to the ValueStringBuilder", firstValue), ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 6
 await testRunner.AndAsync(string.Format("I append \'{0}\' to the ValueStringBuilder", secondValue), ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 7
 await testRunner.WhenAsync("I get the string from the ValueStringBuilder", ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
#line 8
 await testRunner.ThenAsync(string.Format("the ValueStringBuilder string should be \'{0}{1}\'", firstValue, secondValue), ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Grows")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Append content into a ValueStringBuilder")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DataRowAttribute("Span", "11", "Hello, world!", "It is mighty fine to see you today.", "ToString", null)]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DataRowAttribute("Capacity", "11", "Hello, world!", "It is mighty fine to see you today.", "ToString", null)]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DataRowAttribute("Span", "11", "Hello, world!", "It is mighty fine to see you today.", "GetRentedBuffer", null)]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DataRowAttribute("Capacity", "11", "Hello, world!", "It is mighty fine to see you today.", "GetRentedBuffer", null)]
        public async System.Threading.Tasks.Task Grows(string initializationType, string initialLength, string firstValue, string secondValue, string getStringMechanism, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("InitializationType", initializationType);
            argumentsOfScenario.Add("InitialLength", initialLength);
            argumentsOfScenario.Add("FirstValue", firstValue);
            argumentsOfScenario.Add("SecondValue", secondValue);
            argumentsOfScenario.Add("GetStringMechanism", getStringMechanism);
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("Grows", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 16
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 17
    await testRunner.GivenAsync(string.Format("a ValueStringBuilder initialized with \'{0}\' of length {1}", initializationType, initialLength), ((string)(null)), ((global::Reqnroll.Table)(null)), "Given ");
#line hidden
#line 18
 await testRunner.AndAsync(string.Format("I append \'{0}\' to the ValueStringBuilder", firstValue), ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 19
 await testRunner.AndAsync(string.Format("I append \'{0}\' to the ValueStringBuilder", secondValue), ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 20
 await testRunner.WhenAsync(string.Format("I get the string from the ValueStringBuilder via {0}", getStringMechanism), ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
#line 21
 await testRunner.ThenAsync(string.Format("the ValueStringBuilder string should be \'{0}{1}\'", firstValue, secondValue), ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Append number")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Append content into a ValueStringBuilder")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DataRowAttribute("Span", "13", "Hello, world!", "42", null)]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DataRowAttribute("Capacity", "13", "Hello, world!", "42", null)]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DataRowAttribute("Span", "15", "Hello, world!", "42", null)]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DataRowAttribute("Capacity", "15", "Hello, world!", "42", null)]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DataRowAttribute("Span", "13", "Hello, world!", "-42", null)]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DataRowAttribute("Capacity", "13", "Hello, world!", "-42", null)]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DataRowAttribute("Span", "15", "Hello, world!", "-42", null)]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DataRowAttribute("Capacity", "15", "Hello, world!", "-42", null)]
        public async System.Threading.Tasks.Task AppendNumber(string initializationType, string initialLength, string firstValue, string secondValue, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("InitializationType", initializationType);
            argumentsOfScenario.Add("InitialLength", initialLength);
            argumentsOfScenario.Add("FirstValue", firstValue);
            argumentsOfScenario.Add("SecondValue", secondValue);
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("Append number", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 29
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 30
    await testRunner.GivenAsync(string.Format("a ValueStringBuilder initialized with \'{0}\' of length {1}", initializationType, initialLength), ((string)(null)), ((global::Reqnroll.Table)(null)), "Given ");
#line hidden
#line 31
 await testRunner.AndAsync(string.Format("I append \'{0}\' to the ValueStringBuilder", firstValue), ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 32
 await testRunner.AndAsync(string.Format("I append the Int32 {0} to the ValueStringBuilder", secondValue), ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 33
 await testRunner.WhenAsync("I get the string from the ValueStringBuilder", ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
#line 34
 await testRunner.ThenAsync(string.Format("the ValueStringBuilder string should be \'{0}{1}\'", firstValue, secondValue), ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Append number then string")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Append content into a ValueStringBuilder")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DataRowAttribute("Span", "13", "42", "Hello, world!", null)]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DataRowAttribute("Capacity", "13", "42", "Hello, world!", null)]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DataRowAttribute("Span", "15", "42", "Hello, world!", null)]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DataRowAttribute("Capacity", "15", "42", "Hello, world!", null)]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DataRowAttribute("Span", "13", "-42", "Hello, world!", null)]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DataRowAttribute("Capacity", "13", "-42", "Hello, world!", null)]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DataRowAttribute("Span", "15", "-42", "Hello, world!", null)]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DataRowAttribute("Capacity", "15", "-42", "Hello, world!", null)]
        public async System.Threading.Tasks.Task AppendNumberThenString(string initializationType, string initialLength, string firstValue, string secondValue, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("InitializationType", initializationType);
            argumentsOfScenario.Add("InitialLength", initialLength);
            argumentsOfScenario.Add("FirstValue", firstValue);
            argumentsOfScenario.Add("SecondValue", secondValue);
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("Append number then string", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 46
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 47
    await testRunner.GivenAsync(string.Format("a ValueStringBuilder initialized with \'{0}\' of length {1}", initializationType, initialLength), ((string)(null)), ((global::Reqnroll.Table)(null)), "Given ");
#line hidden
#line 48
 await testRunner.AndAsync(string.Format("I append the Int32 {0} to the ValueStringBuilder", firstValue), ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 49
 await testRunner.AndAsync(string.Format("I append \'{0}\' to the ValueStringBuilder", secondValue), ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 50
 await testRunner.WhenAsync("I get the string from the ValueStringBuilder", ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
#line 51
 await testRunner.ThenAsync(string.Format("the ValueStringBuilder string should be \'{0}{1}\'", firstValue, secondValue), ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
    }
}
#pragma warning restore
#endregion