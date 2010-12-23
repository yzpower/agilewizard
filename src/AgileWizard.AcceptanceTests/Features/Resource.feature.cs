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
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Add Simple Resource", ((string[])(null)));
#line 6
this.ScenarioSetup(scenarioInfo);
#line 7
 testRunner.Given("login already");
#line 8
 testRunner.And("open adding-resource page");
#line 9
 testRunner.And("enter title - \'simple Resource\' and content - \'simple Content\' and author - \'Dani" +
                    "el\' and reference url - \'http://www.cnblogs.com/tengzy/\' and tags - \'Agile,Shang" +
                    "hai\'");
#line 10
 testRunner.When("press submit button");
#line 11
 testRunner.Then("resource details page should be shown");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [Xunit.FactAttribute()]
        [Xunit.TraitAttribute("FeatureTitle", "Resource")]
        [Xunit.TraitAttribute("Description", "Edit A Resource")]
        public virtual void EditAResource()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Edit A Resource", ((string[])(null)));
#line 13
this.ScenarioSetup(scenarioInfo);
#line 14
 testRunner.Given("login already");
#line 15
 testRunner.And("open resource list page");
#line 16
 testRunner.And("edit a resource titled with \'Embeded Video\'");
#line 17
 testRunner.And("enter title - \'Embeded Video\' and content - \'Modified Content\' and author - \'Dani" +
                    "el\' and reference url - \'http://www.cnblogs.com/tengzy/\'");
#line 18
 testRunner.When("press submit button");
#line 19
 testRunner.Then("resource details page should be shown");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [Xunit.FactAttribute()]
        [Xunit.TraitAttribute("FeatureTitle", "Resource")]
        [Xunit.TraitAttribute("Description", "Add Resource require login")]
        public virtual void AddResourceRequireLogin()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Add Resource require login", ((string[])(null)));
#line 21
this.ScenarioSetup(scenarioInfo);
#line 22
 testRunner.Given("no login");
#line 23
 testRunner.And("open adding-resource page");
#line 24
 testRunner.Then("login page should be open");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [Xunit.FactAttribute()]
        [Xunit.TraitAttribute("FeatureTitle", "Resource")]
        [Xunit.TraitAttribute("Description", "View Resource Detail")]
        public virtual void ViewResourceDetail()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("View Resource Detail", ((string[])(null)));
#line 26
this.ScenarioSetup(scenarioInfo);
#line 27
 testRunner.Given("open resource list page");
#line 28
 testRunner.When("open a resource titled with \'Embeded Video\'");
#line 29
 testRunner.Then("resource details page title with - \'Embeded Video\' should be shown");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [Xunit.FactAttribute()]
        [Xunit.TraitAttribute("FeatureTitle", "Resource")]
        [Xunit.TraitAttribute("Description", "View Resource List")]
        public virtual void ViewResourceList()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("View Resource List", ((string[])(null)));
#line 31
this.ScenarioSetup(scenarioInfo);
#line 32
 testRunner.Given("login already");
#line 33
 testRunner.And("open resource list page");
#line 34
 testRunner.Then("resoure list page should be in current culture");
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
