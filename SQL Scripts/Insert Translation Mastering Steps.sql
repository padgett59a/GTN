
-- Translation
-- ============================
use gtn
delete from translationsteps
DBCC CHECKIDENT ('[translationsteps]', RESEED, 0);
select * from translationsteps

insert into translationsteps values('Audio Translated', null, null)
insert into translationsteps values('Check Translation File and Create AIFF', null, null)
insert into translationsteps values('Back up GB and AIFF files to External Drive', null, null)
insert into translationsteps values('Translation Double-Checked', null, null)
insert into translationsteps values('Editable Outline Translated', null, null)
insert into translationsteps values('PDF Outline Created', null, null)
insert into translationsteps values('Lower Third Text Translated', null, null)


select * from translationsteps

--Mastering
--=========
use gtn
delete from masteringsteps
DBCC CHECKIDENT ('[masteringsteps]', RESEED, 100);
select * from masteringsteps

insert into masteringsteps values('Aligned', null, null)
insert into masteringsteps values('XP Cut', null, null)
insert into masteringsteps values('Audio Editing:', null, null)
insert into masteringsteps values('BL ISOM DVD Mastering Paid-Location of Masters', null, null)
insert into masteringsteps values('BL GTN DVD Mastering Paid-Location of Masters', null, null)
insert into masteringsteps values('XP ISOM DVD Mastering Paid-Location of Masters', null, null)
insert into masteringsteps values('XP GTN DVD Mastering Paid-Location of Masters', null, null)
insert into masteringsteps values('BL ISOM mp3 ', null, null)
insert into masteringsteps values('BL ISOM mp4', null, null)
insert into masteringsteps values('XP ISOM  mp3', null, null)
insert into masteringsteps values('XP ISOM  Mp4', null, null)
insert into masteringsteps values('BL GTN mp3 ', null, null)
insert into masteringsteps values('BL GTN mp4', null, null)
insert into masteringsteps values('XP GTN mp3', null, null)
insert into masteringsteps values('XP GTN mp4', null, null)
insert into masteringsteps values('Cloud Mastering Files Archived', null, null)
insert into masteringsteps values('Cloud DVD/MP3/MP4 Archived', null, null)
insert into masteringsteps values('ISOM Archive Complete', null, null)
insert into masteringsteps values('ISOM DVD/MP3/MP4 Archived', null, null)
insert into masteringsteps values('GTN Archive Complete', null, null)
insert into masteringsteps values('GTN DVD/MP3/MP4 Archived', null, null)
insert into masteringsteps values('Delhi Archive Complete', null, null)
insert into masteringsteps values('Delhi DVD/MP3/MP4 Archived', null, null)

select * from translationsteps union select * from masteringsteps 