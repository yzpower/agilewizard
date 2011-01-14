// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.4.0.0
//      Runtime Version:4.0.30319.1
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
namespace AgileWizard.AcceptanceTests.Features
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.4.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class ResourceFeature : Xunit.IUseFixture<ResourceFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "Resource.feature"
#line hidden
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Resource", "In order to manage resources\r\nAs a admin\r\nI should be able to add/edit a resource" +
                    " onto website", GenerationTargetLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public virtual void SetFixture(ResourceFeature.FixtureData fixtureData)
        {
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        void System.IDisposable.Dispose()
        {
            this.ScenarioTearDown();
        }
        
        [Xunit.FactAttribute()]
        [Xunit.TraitAttribute("FeatureTitle", "Resource")]
        [Xunit.TraitAttribute("Description", "Add and edit Resource")]
        public virtual void AddAndEditResource()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Add and edit Resource", ((string[])(null)));
#line 6
this.ScenarioSetup(scenarioInfo);
#line 7
 testRunner.Given("login already");
#line 8
 testRunner.And("open adding-resource page");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Value"});
            table1.AddRow(new string[] {
                        "Title",
                        "Test Embeded Video"});
            table1.AddRow(new string[] {
                        "Content",
                        "Created Content"});
            table1.AddRow(new string[] {
                        "Author",
                        "Daniel"});
            table1.AddRow(new string[] {
                        "ReferenceUrl",
                        "http://www.cnblogs.com/tengzy/"});
            table1.AddRow(new string[] {
                        "Tags",
                        "Agile,Shanghai"});
#line 9
 testRunner.And("enter data in resource page", ((string)(null)), table1);
#line 16
 testRunner.And("press submit button");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Value"});
            table2.AddRow(new string[] {
                        "Title",
                        "Test Embeded Video"});
            table2.AddRow(new string[] {
                        "Content",
                        "Created Content"});
            table2.AddRow(new string[] {
                        "Author",
                        "Daniel"});
            table2.AddRow(new string[] {
                        "ReferenceUrl",
                        "http://www.cnblogs.com/tengzy/"});
            table2.AddRow(new string[] {
                        "Tags",
                        "Agile,Shanghai"});
#line 17
 testRunner.Then("current page should be resource details page", ((string)(null)), table2);
#line 24
 testRunner.Then("open resource list page and validate culture and total count");
#line 25
 testRunner.Then("go resource edit page with title - Test Embeded Video");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Value"});
            table3.AddRow(new string[] {
                        "Title",
                        "Modified Title"});
            table3.AddRow(new string[] {
                        "Content",
                        "Modified Content"});
            table3.AddRow(new string[] {
                        "Author",
                        "Test Author"});
            table3.AddRow(new string[] {
                        "ReferenceUrl",
                        "http://testurl.com/"});
            table3.AddRow(new string[] {
                        "Tags",
                        "TestTag"});
#line 26
 testRunner.Then("update resource data", ((string)(null)), table3);
#line 33
 testRunner.Then("press submit button");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Value"});
            table4.AddRow(new string[] {
                        "Title",
                        "Modified Title"});
            table4.AddRow(new string[] {
                        "Content",
                        "Modified Content"});
            table4.AddRow(new string[] {
                        "Author",
                        "Test Author"});
            table4.AddRow(new string[] {
                        "ReferenceUrl",
                        "http://testurl.com/"});
            table4.AddRow(new string[] {
                        "Tags",
                        "TestTag"});
#line 34
 testRunner.Then("page should be redirected to details page", ((string)(null)), table4);
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.4.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                ResourceFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                ResourceFeature.FeatureTearDown();
            }
        }
    }
}
#endregion
