CREATE TABLE Books (
   Id bigserial PRIMARY KEY,
   Title VARCHAR (200) NOT NULL,
   Description VARCHAR (3000)
);

INSERT INTO Books (Title, Description) Values('The Idiot', 'Returning to Russia from a sanitarium in Switzerland, the Christ-like epileptic Prince Myshkin finds himself enmeshed in a tangle of love, torn between two women—the notorious kept woman Nastasya and the pure Aglaia—both involved, in turn, with the corrupt, money-hungry Ganya.')
INSERT INTO Books (Title, Description) Values('Thinking, Fast and Slow', 'In the highly anticipated Thinking, Fast and Slow, Kahneman takes us on a groundbreaking tour of the mind and explains the two systems that drive the way we think. System 1 is fast, intuitive, and emotional; System 2 is slower, more deliberative, and more logical.')
INSERT INTO Books (Title, Description) Values('Clean Code: A Handbook of Agile Software Craftsmanship', 'Even bad code can function. But if code isn''t clean, it can bring a development organization to its knees. Every year, countless hours and significant resources are lost because of poorly written code. But it doesn''t have to be that way.')
