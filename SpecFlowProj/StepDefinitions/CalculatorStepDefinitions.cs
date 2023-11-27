using NUnit.Framework;

namespace SpecFlowProj.StepDefinitions
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {
        private int  firstNumber, secondNumber, sum, difference;

        [Given("the first number is (.*)")]
        public void GivenTheFirstNumberIs(int number)
        {
           this.firstNumber = number;
            
        }

        [Given("the second number is (.*)")]
        public void GivenTheSecondNumberIs(int number)
        {
            this.secondNumber = number;
        }

        [When("the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            this.sum = this.firstNumber + this.secondNumber;
        }

        [Then("the sum should be (.*)")]
        public void ThenTheResultShouldBe(int result)
        {
            Assert.AreEqual(this.sum, result);
        }

        [When(@"the second number is subtracted from first number")]
        public void WhenTheSecondNumberIsSubtractedFromFirstNumber()
        {
            this.difference = this.firstNumber - this.secondNumber;
        }

        [Then(@"the difference should be (.*)")]
        public void ThenTheDifferenceShouldBe(int result)
        {
            Assert.AreEqual(this.difference, result);
        }

    }
}