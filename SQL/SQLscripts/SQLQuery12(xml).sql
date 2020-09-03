use ExamShop
create table testXml (id int not null identity primary key, [xml] xml)

 

insert into testXml ([xml])
values
('<order id="2" number="AAAAAAAAAA" date="2020-08-13">
    <article price="200.0000" amount="14.0000000" />
    <article price="30.0000" amount="40.0000000" />
    <article price="16.0000" amount="20.0000000" />
  </order>'),
  ('<order id="3" number="AAAAAAAAAB" date="2019-09-06">
    <article price="30.0000" amount="7.0000000" />
  </order>'),
  ('<order id="4" number="AAAAAAAAAC" date="2020-03-07">
    <article price="30.0000" amount="2.0000000" />
  </order>'),
  ('<order id="5" number="AAAAAAAAAD" date="2020-09-13">
    <article price="16.0000" amount="5.0000000" />
  </order>')