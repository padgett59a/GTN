insert into courses values ((select semesterID from semesters where semestername like 'Career & Workplace Success'),'Applying the Principles for Success','[??]',1,NULL,(select personId from persons where fullname like 'Dr. Ed Turose & Jim Sanderback'),NULL,NULL,NULL,6)




begin tran
insert into courses values ((select semesterID from semesters where semestername like 'Marketplace Module'),'Authority in the Marketplace','[??]',1,NULL,(select personId from persons where fullname like 'Dr. Gordon Bradshaw'),NULL,NULL,NULL,17)
insert into courses values ((select semesterID from semesters where semestername like 'Messenger Module'),'Breaking Intimidation','BI',1,NULL,(select personId from persons where fullname like 'John Bevere'),NULL,NULL,NULL,3)
insert into courses values ((select semesterID from semesters where semestername like 'Messianic Module'),'Breath of the Holies','PBH',1,NULL,(select personId from persons where fullname like 'Perry Stone'),NULL,NULL,NULL,5)
insert into courses values ((select semesterID from semesters where semestername like 'Marketplace Module Extras'),'Changing Culture Through Marketplace Influence','[??]',1,NULL,(select personId from persons where fullname like 'Wes Hone'),NULL,NULL,NULL,23)
insert into courses values ((select semesterID from semesters where semestername like 'Understanding Islam'),'Christian & Islamic Theological Issues','[??]',1,NULL,(select personId from persons where fullname like 'Dr. Sasan Tavassoli'),NULL,NULL,NULL,12)
insert into courses values ((select semesterID from semesters where semestername like 'Understanding Islam'),'Christian Apologetics to Islam','[??]',1,NULL,(select personId from persons where fullname like 'Dr. Joshua Lingel'),NULL,NULL,NULL,9)
insert into courses values ((select semesterID from semesters where semestername like 'Maturity Module'),'Cleansing Stream','[??]',1,NULL,(select personId from persons where fullname like 'Chris Hayward'),NULL,NULL,NULL,8)
insert into courses values ((select semesterID from semesters where semestername like 'Maturity Module'),'Confronting Life''s Issues','[??]',1,NULL,(select personId from persons where fullname like 'Deborah Smith-Pegues'),NULL,NULL,NULL,5)
insert into courses values ((select semesterID from semesters where semestername like 'Marketplace Module'),'Discipling the Nations Through Business','[??]',1,NULL,(select personId from persons where fullname like 'John Anderson'),NULL,NULL,NULL,10)
insert into courses values ((select semesterID from semesters where semestername like 'Marketplace Module Extras'),'Discovering Your Marketplace Assignment','[??]',1,NULL,(select personId from persons where fullname like 'Wende Jones'),NULL,NULL,NULL,18)
insert into courses values ((select semesterID from semesters where semestername like 'Apostolic-Prophetic Module'),'Dominion, Wealth, & Social Transformation','[??]',1,NULL,(select personId from persons where fullname like 'Dr. C. Peter Wagner'),NULL,NULL,NULL,1)
insert into courses values ((select semesterID from semesters where semestername like 'Messenger Module'),'Driven By Eternity','DBE',1,NULL,(select personId from persons where fullname like 'John Bevere'),NULL,NULL,NULL,2)
insert into courses values ((select semesterID from semesters where semestername like 'Marketplace Module'),'Economic, Social, and Enviromental Business','[??]',1,NULL,(select personId from persons where fullname like 'Al Caperna'),NULL,NULL,NULL,8)
insert into courses values ((select semesterID from semesters where semestername like 'Messianic Module'),'Enmity Between the Two Seeds','PES',1,NULL,(select personId from persons where fullname like 'Bill Cloud'),NULL,NULL,NULL,8)
insert into courses values ((select semesterID from semesters where semestername like 'Marketplace Module'),'Ethics in the Marketplace','[??]',1,NULL,(select personId from persons where fullname like 'Dr. Graham Power'),NULL,NULL,NULL,1)
insert into courses values ((select semesterID from semesters where semestername like 'Christian Apologetics'),'Evidence That Demands a Verdict','[??]',1,NULL,(select personId from persons where fullname like 'Josh McDowell'),NULL,NULL,NULL,8)
insert into courses values ((select semesterID from semesters where semestername like 'Messenger Module'),'Extraordinary','EX',1,NULL,(select personId from persons where fullname like 'John Bevere'),NULL,NULL,NULL,1)
insert into courses values ((select semesterID from semesters where semestername like 'Marketplace Module Extras'),'Faith in the Marketplace','[??]',1,NULL,(select personId from persons where fullname like 'Phil Tan'),NULL,NULL,NULL,16)
insert into courses values ((select semesterID from semesters where semestername like 'Career & Workplace Success'),'Getting Focused to See Results','[??]',1,NULL,(select personId from persons where fullname like 'Dr. Ed Turose'),NULL,NULL,NULL,4)
insert into courses values ((select semesterID from semesters where semestername like 'Marketplace Module'),'Global Business, Am I My Brother''s Keeper?','[??]',1,NULL,(select personId from persons where fullname like 'Ram Gidoomal'),NULL,NULL,NULL,11)
insert into courses values ((select semesterID from semesters where semestername like 'Marketplace Module'),'How to Choose the Right Employees','[??]',1,NULL,(select personId from persons where fullname like 'Dr. Jorg Knoblauch'),NULL,NULL,NULL,27)
insert into courses values ((select semesterID from semesters where semestername like 'Marketplace Module'),'How to Strategically Prepare for Any Negotiation','[??]',1,NULL,(select personId from persons where fullname like 'Robert M. Benedict'),NULL,NULL,NULL,69)
insert into courses values ((select semesterID from semesters where semestername like 'Marketplace Module'),'Intercession in the Marketplace','[??]',1,NULL,(select personId from persons where fullname like 'Dr. Gayle Rogers'),NULL,NULL,NULL,14)
insert into courses values ((select semesterID from semesters where semestername like 'Messianic Module'),'Israel and the Church','PIC',1,NULL,(select personId from persons where fullname like 'Curt Landry'),NULL,NULL,NULL,9)
insert into courses values ((select semesterID from semesters where semestername like 'Marketplace Module'),'Kingdom Enterprise','[??]',1,NULL,(select personId from persons where fullname like 'Jackie Seeno'),NULL,NULL,NULL,9)
insert into courses values ((select semesterID from semesters where semestername like 'Marketplace Module Extras'),'Kingdom Wealth','[??]',1,NULL,(select personId from persons where fullname like 'Dr. C. Peter Wagner'),NULL,NULL,NULL,13)
insert into courses values ((select semesterID from semesters where semestername like 'Maturity Module'),'Leadership Principles','[??]',1,NULL,(select personId from persons where fullname like 'Phil Pringle'),NULL,NULL,NULL,3)
insert into courses values ((select semesterID from semesters where semestername like 'Christian Apologetics'),'Loving God with All Your Mind','[??]',1,NULL,(select personId from persons where fullname like 'Dr. J. P. Moreland'),NULL,NULL,NULL,6)
insert into courses values ((select semesterID from semesters where semestername like 'Marketplace Module'),'Managing by Character','[??]',1,NULL,(select personId from persons where fullname like 'Jim Cobrae'),NULL,NULL,NULL,4)
insert into courses values ((select semesterID from semesters where semestername like 'Marketplace Module'),'Marketing and Keys to Success','[??]',1,NULL,(select personId from persons where fullname like 'Dr. Ed Turose'),NULL,NULL,NULL,20)
insert into courses values ((select semesterID from semesters where semestername like 'Marketplace Module Extras'),'Marketing to Government and Big Business','[??]',1,NULL,(select personId from persons where fullname like 'Sher Valenzuela'),NULL,NULL,NULL,19)
insert into courses values ((select semesterID from semesters where semestername like 'Understanding Islam'),'Muslim Evangelism','[??]',1,NULL,(select personId from persons where fullname like 'Jay Smith'),NULL,NULL,NULL,11)
insert into courses values ((select semesterID from semesters where semestername like 'Maturity Module'),'Navigating Betrayal','[??]',1,NULL,(select personId from persons where fullname like 'Dr. David Sumrall'),NULL,NULL,NULL,2)
insert into courses values ((select semesterID from semesters where semestername like 'Marketplace Module'),'Ousting Babylon from the Marketplace','[??]',1,NULL,(select personId from persons where fullname like 'Dave Hodgson'),NULL,NULL,NULL,12)
insert into courses values ((select semesterID from semesters where semestername like 'Marketplace Module Extras'),'Overcoming Workplace Challenges in a Post-Christian Enviroment','[??]',1,NULL,(select personId from persons where fullname like 'Timo Plutschinski'),NULL,NULL,NULL,6)
insert into courses values ((select semesterID from semesters where semestername like 'Marketplace Module'),'Practical Tips for Starting New Businesses','[??]',1,NULL,(select personId from persons where fullname like 'Dr. Erik Kudlis'),NULL,NULL,NULL,21)
insert into courses values ((select semesterID from semesters where semestername like 'Career & Workplace Success'),'Preparing For The Future','[??]',1,NULL,(select personId from persons where fullname like 'Dr. Ed Turose'),NULL,NULL,NULL,3)
insert into courses values ((select semesterID from semesters where semestername like 'Messianic Module'),'Prophetic Discoveries Hidden in God''s Seven Appointed Feasts','PIC',1,NULL,(select personId from persons where fullname like 'Perry Stone'),NULL,NULL,NULL,6)
insert into courses values ((select semesterID from semesters where semestername like 'Messianic Module'),'Prophetic Mysteries of the Seven Feasts of Israel','PSF',1,NULL,(select personId from persons where fullname like 'Perry Stone & Bill Cloud'),NULL,NULL,NULL,1)
insert into courses values ((select semesterID from semesters where semestername like 'Marketplace Module'),'Reaching a Tipping Point','[??]',1,NULL,(select personId from persons where fullname like 'Dave Hodgson'),NULL,NULL,NULL,71)
insert into courses values ((select semesterID from semesters where semestername like 'Marketplace Module'),'Receiving Your Inheritance','[??]',1,NULL,(select personId from persons where fullname like 'Os Hillman'),NULL,NULL,NULL,60)
insert into courses values ((select semesterID from semesters where semestername like 'Marketplace Module Extras'),'Reforming the Marketplace','[??]',1,NULL,(select personId from persons where fullname like 'Dr. Bruce Cook'),NULL,NULL,NULL,7)
insert into courses values ((select semesterID from semesters where semestername like 'Marketplace Module'),'Relating to Pastoral Covering','[??]',1,NULL,(select personId from persons where fullname like 'Dave Hodgson'),NULL,NULL,NULL,33)
insert into courses values ((select semesterID from semesters where semestername like 'Maturity Module'),'Sexual Wholeness & Healing','[??]',1,NULL,(select personId from persons where fullname like 'Dr. Doug Weiss'),NULL,NULL,NULL,4)
insert into courses values ((select semesterID from semesters where semestername like 'Marketplace Module'),'Shepherding Business & Marketplace Leaders','[??]',1,NULL,(select personId from persons where fullname like 'Frank Lopez'),NULL,NULL,NULL,5)
insert into courses values ((select semesterID from semesters where semestername like 'Marketplace Module Extras'),'Shepherding Business & Marketplace Leaders','[??]',1,NULL,(select personId from persons where fullname like 'Frank Lopez'),NULL,NULL,NULL,5)
insert into courses values ((select semesterID from semesters where semestername like 'Messianic Module'),'The Ancient Jewish Wedding','PAJ',1,NULL,(select personId from persons where fullname like 'Perry Stone'),NULL,NULL,NULL,3)
insert into courses values ((select semesterID from semesters where semestername like 'Maturity Module'),'The Blessed Life','[??]',1,NULL,(select personId from persons where fullname like 'Robert Morris'),NULL,NULL,NULL,7)
insert into courses values ((select semesterID from semesters where semestername like 'Messianic Module'),'The Code of the Priest','PCP',1,NULL,(select personId from persons where fullname like 'Perry Stone'),NULL,NULL,NULL,4)
insert into courses values ((select semesterID from semesters where semestername like 'Apostolic-Prophetic Module'),'The Discerner','[??]',1,NULL,(select personId from persons where fullname like 'James W. Goll'),NULL,NULL,NULL,3)
insert into courses values ((select semesterID from semesters where semestername like 'Marketplace Module'),'The Economics of Mutuality','[??]',1,NULL,(select personId from persons where fullname like 'Bruno Roche'),NULL,NULL,NULL,67)
insert into courses values ((select semesterID from semesters where semestername like 'Marketplace Module'),'The Five-Fold Effect in the Marketplace','[??]',1,NULL,(select personId from persons where fullname like 'Walt Pilcher'),NULL,NULL,NULL,25)
insert into courses values ((select semesterID from semesters where semestername like 'Marketplace Module'),'The Journey to National Transformation','[??]',1,NULL,(select personId from persons where fullname like 'Patrick Kuwana'),NULL,NULL,NULL,2)
insert into courses values ((select semesterID from semesters where semestername like 'Maturity Module'),'The Marriage Trinity','[??]',1,NULL,(select personId from persons where fullname like 'Dr. Doug Weiss'),NULL,NULL,NULL,6)
insert into courses values ((select semesterID from semesters where semestername like 'Christian Apologetics'),'The Master Plan of Evangelism','[??]',1,NULL,(select personId from persons where fullname like 'Dr. Robert Coleman'),NULL,NULL,NULL,7)
insert into courses values ((select semesterID from semesters where semestername like 'Marketplace Module'),'The Nehemiah People','[??]',1,NULL,(select personId from persons where fullname like 'Paul Cuny'),NULL,NULL,NULL,15)
insert into courses values ((select semesterID from semesters where semestername like 'Marketplace Module'),'The Power of the Tithe','[??]',1,NULL,(select personId from persons where fullname like 'Robert M. Benedict'),NULL,NULL,NULL,70)
insert into courses values ((select semesterID from semesters where semestername like 'Apostolic-Prophetic Module'),'The Seer','[??]',1,NULL,(select personId from persons where fullname like 'James W. Goll'),NULL,NULL,NULL,2)
insert into courses values ((select semesterID from semesters where semestername like 'Maturity Module'),'The Seven Mountain Strategy','[??]',1,NULL,(select personId from persons where fullname like 'Dr. Lance Wallnau'),NULL,NULL,NULL,1)
insert into courses values ((select semesterID from semesters where semestername like 'Marketplace Module'),'Understanding Business Cycles & Kingdom Purposes','[??]',1,NULL,(select personId from persons where fullname like 'Mani Erfan'),NULL,NULL,NULL,22)
insert into courses values ((select semesterID from semesters where semestername like 'Career & Workplace Success'),'Understanding Self and Others','[??]',1,NULL,(select personId from persons where fullname like 'Dr. Ed Turose & Jim Sanderback'),NULL,NULL,NULL,1)
insert into courses values ((select semesterID from semesters where semestername like 'Marketplace Module Extras'),'Understanding the Relational Side of Business','[??]',1,NULL,(select personId from persons where fullname like 'Dr. Michael Schluter'),NULL,NULL,NULL,24)
insert into courses values ((select semesterID from semesters where semestername like 'Marketplace Module'),'Understanding Your Purpose','[??]',1,NULL,(select personId from persons where fullname like 'Os Hillman'),NULL,NULL,NULL,59)
insert into courses values ((select semesterID from semesters where semestername like 'Messianic Module'),'Unlocking Hebrew Mysteries','PUH',1,NULL,(select personId from persons where fullname like 'Perry Stone & Bill Cloud'),NULL,NULL,NULL,2)
insert into courses values ((select semesterID from semesters where semestername like 'Career & Workplace Success'),'Vocational & Career Planning','[??]',1,NULL,(select personId from persons where fullname like 'Dr. Ed Turose'),NULL,NULL,NULL,2)
insert into courses values ((select semesterID from semesters where semestername like 'Marketplace Module Extras'),'Warrior Craftsmen','[??]',1,NULL,(select personId from persons where fullname like 'Liz Hawley'),NULL,NULL,NULL,3)
insert into courses values ((select semesterID from semesters where semestername like 'Career & Workplace Success'),'Workplace Preparation Skills','[??]',1,NULL,(select personId from persons where fullname like 'Dr. Ed Turose & Jim Sanderback'),NULL,NULL,NULL,5)

commit tran

select * from courses where coursename like 'cleansing%'

begin tran
update courses set notes = 'Other instructors: Chad Daniel, Raymond Petitt' where courseID = 90

rollback tran