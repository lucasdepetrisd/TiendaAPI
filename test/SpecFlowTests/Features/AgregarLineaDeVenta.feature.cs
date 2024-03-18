﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace SpecFlowTests.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class AgregarArticulosAVentaFeature : object, Xunit.IClassFixture<AgregarArticulosAVentaFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "AgregarLineaDeVenta.feature"
#line hidden
        
        public AgregarArticulosAVentaFeature(AgregarArticulosAVentaFeature.FixtureData fixtureData, SpecFlowTests_XUnitAssemblyFixture assemblyFixture, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "Agregar articulos a venta", "  Como vendedor\r\n  Quiero agregar artículos a las ventas\r\n  Para registrar las co" +
                    "mpras de los clientes y conocer el total de la venta", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
        public virtual void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        void System.IDisposable.Dispose()
        {
            this.TestTearDown();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Agregar articulo a la venta con exito")]
        [Xunit.TraitAttribute("FeatureTitle", "Agregar articulos a venta")]
        [Xunit.TraitAttribute("Description", "Agregar articulo a la venta con exito")]
        public virtual void AgregarArticuloALaVentaConExito()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Agregar articulo a la venta con exito", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 6
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 7
    testRunner.Given("una venta en proceso en un punto de venta de la sucursal \"Centro\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                            "Descripcion",
                            "Marca",
                            "Categoria",
                            "Precio",
                            "PorcentajeIVA",
                            "MargenGanancia"});
                table1.AddRow(new string[] {
                            "Zapatillas altas",
                            "Adidas",
                            "Zapatillas",
                            "1000",
                            "21",
                            "30"});
#line 8
    testRunner.And("un articulo con codigo \"1234\" con los siguientes datos:", ((string)(null)), table1, "And ");
#line hidden
                TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                            "idInventario",
                            "Color",
                            "Talle",
                            "Cantidad"});
                table2.AddRow(new string[] {
                            "1",
                            "Blanco",
                            "38",
                            "10"});
                table2.AddRow(new string[] {
                            "2",
                            "Negro",
                            "40",
                            "5"});
                table2.AddRow(new string[] {
                            "3",
                            "Rojo",
                            "38",
                            "8"});
#line 11
    testRunner.And("el inventario disponible para una combinacion de talles y colores para la sucursa" +
                        "l \"Centro\" es la siguiente:", ((string)(null)), table2, "And ");
#line hidden
#line 16
    testRunner.When("agrego a la venta con cantidad 1 el inventario de id 3:", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
                TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                            "Cantidad",
                            "Codigo",
                            "Descripcion",
                            "Talle",
                            "Color",
                            "NetoGravado",
                            "MontoIVA",
                            "Subtotal"});
                table3.AddRow(new string[] {
                            "1",
                            "1234",
                            "Zapatillas altas",
                            "38",
                            "Rojo",
                            "1300",
                            "273",
                            "1573"});
#line 17
    testRunner.Then("la linea de venta sera de la siguiente manera:", ((string)(null)), table3, "Then ");
#line hidden
#line 20
    testRunner.And("el total de la venta sera 1573.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                AgregarArticulosAVentaFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                AgregarArticulosAVentaFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
