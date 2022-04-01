select A.courseCoreID, A.LangID, count(TL.tsID) as SessionTrxTotal
from courses A
join SessionCores SC on SC.courseCoreID = A.courseCoreID 
join Sessions S on S.SessionCoreID = SC.SessionCoreID  and S.langID = A.langID
join TranslationLog TL on TL.sessionID = S.sessionID -- and TL.statusID = 1
where S.langID = A.langID
group by A.courseCoreID, A.LangID
--having S.langID = A.langID

select * from sessions
select * from translationlog

use [gtn-dev]
--use [gtn]
CREATE NONCLUSTERED INDEX idx_Sessions_langID ON Sessions ([langID]);

select A.courseCoreID, A.LangID, count(TL.tsID) as SessionTrxTotal
from courses A
join SessionCores SC on SC.courseCoreID = A.courseCoreID 
join Sessions S on S.SessionCoreID = SC.SessionCoreID  and S.langID = A.langID
--join TranslationLog TL on TL.sessionID = S.sessionID -- and TL.statusID = 1
group by A.courseCoreID, A.LangID

--This one!
select SC.courseCoreID, S.LangID, count(TL.tsID) as SessionTrxTotal
from SessionCores SC 
join Sessions S on S.SessionCoreID = SC.SessionCoreID  
join TranslationLog TL on TL.sessionID = S.sessionID -- and TL.statusID = 1
group by SC.courseCoreID, S.LangID
