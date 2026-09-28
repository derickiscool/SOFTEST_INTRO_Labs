@Factorial
Feature: UsingCalculatorFactorial

In order to understand combinations and permutations
As a math enthusiast
I want to calculate factorials of positive integers

Scenario: Calculate normal factorial
  Given I have a calculator
  When I have entered 5 into the calculator and press factorial
  Then the factorial result should be 120

Scenario: Calculate identity factorial case
  Given I have a calculator
  When I have entered 0 into the calculator and press factorial
  Then the factorial result should be 1

Scenario: Reject unsupported factorial inputs
  Given I have a calculator
  When I have entered -1 into the calculator and press factorial
  Then factorial should be rejected