using System.Collections.Generic;
using JetBrains.ProjectModel;
using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.UnitTestFramework;
using NBehave.ReSharper.Plugin.UnitTestRunner;

namespace NBehave.ReSharper.Plugin.UnitTestProvider
{
    public class NBehaveScenarioTestElement : NBehaveUnitTestElementBase
    {
        private readonly string _scenario;

        public NBehaveScenarioTestElement(string scenario, IProjectFile featureFile, TestProvider testProvider, ProjectModelElementEnvoy projectModel,
                                          NBehaveUnitTestElementBase parent)
            : base(featureFile, testProvider, parent.Id + "/" + scenario, projectModel, parent)
        {
            _scenario = scenario;
        }

        public override string ShortName
        {
            get { return Scenario; }
        }

        public override string Kind
        {
            get { return "NBehave scenario"; }
        }

        public string Scenario
        {
            get { return _scenario; }
        }

        public override string GetPresentation()
        {
            return Scenario;
        }

        public override IList<UnitTestTask> GetTaskSequence(IEnumerable<IUnitTestElement> explicitElements)
        {
            var taskSequence = (Parent != null) ? Parent.GetTaskSequence(explicitElements) : new List<UnitTestTask>();
            taskSequence.Add(new UnitTestTask(this, new NBehaveScenarioTask(FeatureFile, _scenario)));
            return taskSequence;
        }

        public override UnitTestElementDisposition GetDisposition()
        {
            //Denna metod anropas om man tex trycker p� enter p� en nod.
            return null;
        }

        public override IDeclaredElement GetDeclaredElement()
        {
            return null;
        }

        public bool Equals(NBehaveScenarioTestElement other)
        {
            if (other == null)
                return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Equals(other._scenario, _scenario);
        }

        public override bool Equals(IUnitTestElement other)
        {
            return Equals(other as NBehaveScenarioTestElement);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as NBehaveScenarioTestElement);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (base.GetHashCode() * 397) ^ _scenario.GetHashCode();
            }
        }
    }
}