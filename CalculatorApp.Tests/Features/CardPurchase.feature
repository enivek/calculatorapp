Feature: Card Purchase

As a cashier, 
I would like to calculate the final price of an item 
so that I can charge the customer correctly.

Background:
  Given a credit card fee table
  | card       | fee   |
  | Visa       | $2.50 |
  | MasterCard | $3.50 |
  | Other      | $1.00 |

Scenario: Simple Price Calculation
  Given a user makes an order with a total price of $100
  When the user attempts to make a purchase
  Then the user should be charged $100

Scenario: Simple Price Calculation with Sales Tax
  Given a user makes an order with a total price of $100
  And the sales tax is 10%
  When the user attempts to make a purchase
  Then the user should be charged $110

Scenario: Calculation of items with a Visa card.
  Given a user makes an order with a total price of $100
  And the sales tax is 10%
  And the user pays with a "Visa" credit card
  When the user attempts to make a purchase
  Then the user should be charged $112.50

Scenario: Calculation of items with a MasterCard
  Given a user makes an order with a total price of $100
  And the sales tax is 10%
  And the user pays with a "MasterCard" credit card
  When the user attempts to make a purchase
  Then the user should be charged $113.50

Scenario: Multiple Simple Price Calculation
  Given a user makes an order with a total price of <total>
  And the sales tax is <salestax>
  When the user attempts to make a purchase
  Then the user should be charged <finalamount>

Examples:

| total | salestax | finalamount |
| $100  | 10%      | $110        |
| $200  | 10%      | $220        |
| $300  | 10%      | $330        |

