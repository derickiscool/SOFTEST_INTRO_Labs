@BasicMusa
Feature: UsingCalculatorBasicReliability

In order to calculate the Basic Musa model's failures and intensities
As a Software Quality Metric enthusiast
I want to use my calculator to do this

Scenario: Calculating current failure intensity at tau zero
  Given I have a calculator
  When I calculate Musa current intensity with lambda0 10, v0 100, and tau 0
  Then the result should be 10

Scenario: Calculating expected cumulative failures after execution time
  Given I have a calculator
  When I calculate Musa cumulative failures with lambda0 10, v0 100, and tau 10
  Then the result should be 63.212055883

Scenario: Rejecting invalid parameters for Musa model
  Given I have a calculator
  When I calculate Musa current intensity with lambda0 -5, v0 100, and tau 10
  Then the operation should be rejected