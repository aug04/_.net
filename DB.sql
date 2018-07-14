create table aug_SQLLogin_1.Options (
	Id int identity primary key not null,
	Name nvarchar(64) not null,
	Value text,
	AutoLoad nvarchar(20) not null default 'yes'
);

create table aug_SQLLogin_1.Posts (
	Id bigint identity primary key not null,
	Author bigint not null,
	PostDate datetime not null,
	PostModified datetime not null,
	Contents nvarchar(MAX) not null,
	Title nvarchar(1000) not null,
	Excerpt nvarchar(4000) not null,
	Status varchar(100) not null,
	PostName varchar(200) not null,
	Guid varchar(255),
	TermsId int not null,
	PostType varchar(100) not null
);

create table aug_SQLLogin_1.TermRelationships (
	ObjectId bigint not null,
	TermTaxonomyId bigint not null,
	TermOrder int,
	primary key (ObjectId, TermTaxonomyId)
);

create table aug_SQLLogin_1.Terms (
	Id int identity primary key not null,
	Name nvarchar(200) not null,
	Slug varchar(200) not null,
	TermGroup int
);

create table aug_SQLLogin_1.TermTaxonomy (
	TermTaxonomyId bigint identity primary key not null,
	TermId bigint not null,
	Taxonomy varchar(255),
	Description nvarchar(1000),
	Parent bigint,
	Count bigint
);

create table aug_SQLLogin_1.Users (
	Id bigint identity primary key not null,
	Username varchar(60) unique not null,
	Password varchar(64) not null,
	Email varchar(100) unique,
	DisplayName nvarchar(250),
	Status bit not null
);