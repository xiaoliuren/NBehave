// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IStringStepRunner.cs" company="NBehave">
//   Copyright (c) 2007, NBehave - http://nbehave.codeplex.com/license
// </copyright>
// <summary>
//   Defines the IStringStepRunner type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace NBehave.Narrator.Framework
{
    public interface IStringStepRunner
    {
        ActionStepResult Run(ActionStepText actionStep);

        ActionStepResult Run(ActionStepText actionStep, Row row);

        void OnCloseScenario();

        void BeforeScenario();

        void AfterScenario();
    }
}