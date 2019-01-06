Feature: Happy Path Place an Order
	
	

@mytag
Scenario Outline: Verify placing an electronic order
	Given I am on '<CurrentPage>' page
	When I select Todays Deals
	Then I should see Todays Deals page
	When I select first deal
	Then I should see related products
Examples:
| CurrentPage |
| Amazon      |

Scenario Outline: Book Tickets on Yatra.com
Given I am on '<CurrentPage>' page
When I select '<DepartureCity>' as departure city
And  I select '<DestinationCity>' as destination city
And  I Select '<DepartDate>' & '<ReturnDate>'
And  I select no of Travellers as '2'
And  I click on search
Then I should see flight details
Examples: 
| CurrentPage | DepartureCity | DestinationCity | DepartDate  | ReturnDate  |
| Yatra       | Mumbai        | Delhi           | 01-01-2019 |             |
| Yatra       | Indore        | Mumbai          | 06-01-2019 | 08-Jan-2019 |


Scenario Outline: Get A quote BUPA
Given I am on '<PageName>' page using '<browser>'
When I click on Get a quote button
Then I should see cover option overlay
When I select 'Health insurance'
Then I should see Pre-text condition overlay
When I 'accept' condition by clicking accept and continue button
Then I should see get a health quote page
When I enter personal details as '<FName>','<LName>','<Title>','<DOB>','<Gendar>','<Occupation>','<Smoke>'
And  I enter contact details as '<PostCode>','<PhoneNum>','<Email>','<QuoteDetails>','<StartDate>'
And  I select Additional family details as '<FamilyMembers>','<Relationship>','<MemberDOB>'
#And  I click on choose your cover button
Examples: 
| PageName | FName | LName | Title | DOB        | Gendar | Occupation | Smoke | PostCode | PhoneNum    | Email     | QuoteDetails | StartDate | FamilyMembers | Relationship      | MemberDOB | browser |
| Bupa     | Javed | Khan  | Mr    | 02/11/1986 | Male   | Engineer   | No    | TW18DZ   | 09876543210 | jk@jk.com | Email        | 2         | 3             | Daughter,Son,Wife | 20,18,45  | chrome  |