INSERT INTO [dbo].[Category] (Title, Description, UserId) VALUES ('Food', 'Expenses with food and drinks', 'test@test.com');
INSERT INTO [dbo].[Category] (Title, Description, UserId) VALUES ('Health', 'Expenses with health and wellness', 'test@test.com');
INSERT INTO [dbo].[Category] (Title, Description, UserId) VALUES ('Transport', 'Costs with transport and vehicles', 'test@test.com');
INSERT INTO [dbo].[Category] (Title, Description, UserId) VALUES ('Housing', 'House-related expenses', 'test@test.com');
INSERT INTO [dbo].[Category] (Title, Description, UserId) VALUES ('Education', 'Expenses with education and courses', 'test@test.com');
INSERT INTO [dbo].[Category] (Title, Description, UserId) VALUES ('Leisure', 'Expenses with leisure activities', 'test@test.com');
INSERT INTO [dbo].[Category] (Title, Description, UserId) VALUES ('Clothing', 'Expenses with clothing', 'test@test.com');
INSERT INTO [dbo].[Category] (Title, Description, UserId) VALUES ('Investments', 'Investments and financial applications', 'test@test.com');
INSERT INTO [dbo].[Category] (Title, Description, UserId) VALUES ('Taxes', 'Tax and fee payments', 'test@test.com');
INSERT INTO [dbo].[Category] (Title, Description, UserId) VALUES ('Travel', 'Expenses with travel and tourism', 'test@test.com');
INSERT INTO [dbo].[Category] (Title, Description, UserId) VALUES ('Gifts', 'Expenses with gifts and donations', 'test@test.com');
INSERT INTO [dbo].[Category] (Title, Description, UserId) VALUES ('Beauty', 'Expenses with beauty and personal care', 'test@test.com');
INSERT INTO [dbo].[Category] (Title, Description, UserId) VALUES ('Pets', 'Expenses with pets', 'test@test.com');
INSERT INTO [dbo].[Category] (Title, Description, UserId) VALUES ('Telecom', 'Costs with telephony and internet', 'test@test.com');
INSERT INTO [dbo].[Category] (Title, Description, UserId) VALUES ('Insurance', 'Various insurance payments', 'test@test.com');
INSERT INTO [dbo].[Category] (Title, Description, UserId) VALUES ('Mental Health', 'Expenses with psychology and therapy', 'test@test.com');
INSERT INTO [dbo].[Category] (Title, Description, UserId) VALUES ('Fitness', 'Expenses with gym and physical activities', 'test@test.com');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Grocery shopping', '2024-01-05', '2024-01-05', 2, -300.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Food'), 'test@test.com');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Gym Membership', '2024-01-10', '2024-01-10', 2, -89.99, (SELECT Id FROM [dbo].[Category] WHERE Title='Fitness'), 'test@test.com');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Bus fare', '2024-01-15', '2024-01-15', 2, -150.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Transport'), 'test@test.com');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Books for course', '2024-01-20', '2024-01-20', 2, -200.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Education'), 'test@test.com');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Salary', '2024-01-25', '2024-01-25', 1, 5000.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Investments'), 'test@test.com');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Medical consultation', '2024-01-26', '2024-01-26', 2, -250.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Health'), 'test@test.com');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Dinner out', '2024-01-27', '2024-01-27', 2, -120.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Leisure'), 'test@test.com');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Dog food', '2024-01-28', '2024-01-28', 2, -75.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Pets'), 'test@test.com');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Life insurance payment', '2024-01-29', '2024-01-29', 2, -150.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Insurance'), 'test@test.com');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Netflix subscription', '2024-02-02', '2024-02-02', 2, -45.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Leisure'), 'test@test.com');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('New clothes', '2024-02-06', '2024-02-06', 2, -300.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Clothing'), 'test@test.com');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Car repair', '2024-02-11', '2024-02-11', 2, -800.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Transport'), 'test@test.com');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Haircut', '2024-02-15', '2024-02-15', 2, -50.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Beauty'), 'test@test.com');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Book purchase', '2024-02-18', '2024-02-18', 2, -120.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Education'), 'test@test.com');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Travel reimbursement', '2024-02-20', '2024-02-20', 1, 1500.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Travel'), 'test@test.com');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('February rent', '2024-02-25', '2024-02-25', 2, -1500.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Housing'), 'test@test.com');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('IPVA', '2024-02-27', '2024-02-27', 2, -400.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Taxes'), 'test@test.com');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Veterinary consultation', '2024-02-28', '2024-02-28', 2, -180.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Pets'), 'test@test.com');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Birthday dinner', '2024-02-28', '2024-02-28', 2, -250.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Leisure'), 'test@test.com');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, [Type], Amount, CategoryId, UserId)
VALUES ('Monthly Salary', '2024-03-01', '2024-03-01', 1, 5000.00, (SELECT TOP 1 Id FROM [dbo].[Category] WHERE Title='Investments'), 'test@test.com');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, [Type], Amount, CategoryId, UserId)
VALUES ('Electricity bill', '2024-03-02', '2024-03-02', 2, -120.00, (SELECT TOP 1 Id FROM [dbo].[Category] WHERE Title='Housing'), 'test@test.com');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, [Type], Amount, CategoryId, UserId)
VALUES ('Water bill', '2024-03-05', '2024-03-05', 2, -80.00, (SELECT TOP 1 Id FROM [dbo].[Category] WHERE Title='Housing'), 'test@test.com');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, [Type], Amount, CategoryId, UserId)
VALUES ('School tuition', '2024-03-10', '2024-03-10', 2, -600.00, (SELECT TOP 1 Id FROM [dbo].[Category] WHERE Title='Education'), 'test@test.com');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, [Type], Amount, CategoryId, UserId)
VALUES ('Clothes shopping', '2024-03-12', '2024-03-12', 2, -300.00, (SELECT TOP 1 Id FROM [dbo].[Category] WHERE Title='Clothing'), 'test@test.com');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, [Type], Amount, CategoryId, UserId)
VALUES ('Purchase of supplements', '2024-03-15', '2024-03-15', 2, -200.00, (SELECT TOP 1 Id FROM [dbo].[Category] WHERE Title='Health'), 'test@test.com');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, [Type], Amount, CategoryId, UserId)
VALUES ('Family restaurant', '2024-03-18', '2024-03-18', 2, -250.00, (SELECT TOP 1 Id FROM [dbo].[Category] WHERE Title='Food'), 'test@test.com');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, [Type], Amount, CategoryId, UserId)
VALUES ('Phone plan', '2024-03-20', '2024-03-20', 2, -150.00, (SELECT TOP 1 Id FROM [dbo].[Category] WHERE Title='Telecom'), 'test@test.com');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, [Type], Amount, CategoryId, UserId)
VALUES ('Weekend trip', '2024-03-22', '2024-03-22', 2, -800.00, (SELECT TOP 1 Id FROM [dbo].[Category] WHERE Title='Travel'), 'test@test.com');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, [Type], Amount, CategoryId, UserId)
VALUES ('Car insurance payment', '2024-03-24', '2024-03-24', 2, -400.00, (SELECT TOP 1 Id FROM [dbo].[Category] WHERE Title='Insurance'), 'test@test.com');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, [Type], Amount, CategoryId, UserId)
VALUES ('Art supplies', '2024-03-26', '2024-03-26', 2, -150.00, (SELECT TOP 1 Id FROM [dbo].[Category] WHERE Title='Leisure'), 'test@test.com');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Freelance income', '2024-05-02', '2024-05-02', 1, 2200.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Investments'), 'test@test.com');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Internet bill', '2024-05-05', '2024-05-05', 2, -89.99, (SELECT Id FROM [dbo].[Category] WHERE Title='Telecom'), 'test@test.com');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Transport expense', '2024-05-07', '2024-05-07', 2, -160.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Transport'), 'test@test.com');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Book purchase', '2024-05-09', '2024-05-09', 2, -120.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Education'), 'test@test.com');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Salary', '2024-05-10', '2024-05-10', 1, 4000.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Investments'), 'test@test.com');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Rent payment', '2024-05-12', '2024-05-12', 2, -1500.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Housing'), 'test@test.com');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Dinner expenses', '2024-05-15', '2024-05-15', 2, -200.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Food'), 'test@test.com');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Medical consultation', '2024-05-18', '2024-05-18', 2, -300.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Health'), 'test@test.com');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Pet food', '2024-05-20', '2024-05-20', 2, -75.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Pets'), 'test@test.com');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Birthday gift', '2024-05-22', '2024-05-22', 2, -150.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Gifts'), 'test@test.com');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Bonus', '2024-05-24', '2024-05-24', 1, 1200.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Investments'), 'test@test.com');

INSERT INTO [Product] VALUES('Annual Plan', '1 year of access to the platform', 'annual-plan', 1, 799.90)

INSERT INTO Voucher VALUES ('1234ABCD', 'Test Voucher', 'Test', 1, 79.9)