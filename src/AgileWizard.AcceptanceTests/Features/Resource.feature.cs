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
        [Xunit.TraitAttribute("Description", "Add Simple Resource")]
        public virtual void AddSimpleResource()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Add Simple Resource", new string[] {
                        "UI"});
#line 7
this.ScenarioSetup(scenarioInfo);
#line 8
 testRunner.Given("login already");
#line 9
 testRunner.And("open adding-resource page");
#line 10
 testRunner.And("enter title - \'simple Resource\' and content - \'simple Content\' and author - \'Dani" +
                    "el\'");
#line 11
 testRunner.And("tags - \'Agile,Shanghai\'");
#line 12
 testRunner.When("press submit button");
#line 13
 testRunner.Then("resource details page should be shown");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [Xunit.FactAttribute()]
        [Xunit.TraitAttribute("FeatureTitle", "Resource")]
        [Xunit.TraitAttribute("Description", "Edit A Resource")]
        public virtual void EditAResource()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Edit A Resource", new string[] {
                        "UI"});
#line 16
this.ScenarioSetup(scenarioInfo);
#line 17
 testRunner.Given("login already");
#line 18
 testRunner.And("open resource list page");
#line 19
 testRunner.And("edit a resource titled with \'Embeded Video\'");
#line 20
 testRunner.And("enter title - \'Embeded Video\' and content - \'Modified Content\' and author - \'Dani" +
                    "el\'");
#line 21
 testRunner.When("press submit button");
#line 22
 testRunner.Then("resource details page should be shown");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [Xunit.FactAttribute()]
        [Xunit.TraitAttribute("FeatureTitle", "Resource")]
        [Xunit.TraitAttribute("Description", "Add Resource require login")]
        public virtual void AddResourceRequireLogin()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Add Resource require login", new string[] {
                        "UI"});
#line 25
this.ScenarioSetup(scenarioInfo);
#line 26
 testRunner.Given("no login");
#line 27
 testRunner.And("open adding-resource page");
#line 28
 testRunner.Then("login page should be open");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [Xunit.FactAttribute()]
        [Xunit.TraitAttribute("FeatureTitle", "Resource")]
        [Xunit.TraitAttribute("Description", "View Resource List")]
        public virtual void ViewResourceList()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("View Resource List", new string[] {
                        "UI"});
#line 31
this.ScenarioSetup(scenarioInfo);
#line 32
 testRunner.Given("login already");
#line 33
 testRunner.And("open resource list page");
#line 34
 testRunner.Then("I can see the page title in current culture");
#line 35
 testRunner.And("I can see the total resouce count");
#line 36
 testRunner.And("I can see the create resource entry in current culture");
#line 37
 testRunner.And("I can see the total resource count in current culture");
#line 38
 testRunner.And("I can see the List in current culture");
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
