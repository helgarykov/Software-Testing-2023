namespace Lab_2;

/// <summary>
/// Represents the different phases that the CalculatorState goes through when processing a calculation.
/// </summary>
public enum CalculatorPhase
{
    /// <summary>Waiting for the first operand to be entered.</summary>
    WaitingForFirstOperand,

    /// <summary>Waiting for an arithmetic operator to be entered.</summary>
    WaitingForOperator,

    /// <summary>Waiting for the second operand to be entered.</summary>
    WaitingForSecondOperand
}