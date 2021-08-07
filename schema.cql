CREATE KEYSPACE IF NOT EXISTS accounts WITH REPLICATION = { 'class' : 'SimpleStrategy', 'replication_factor' : '1' };

CREATE TABLE IF NOT EXISTS accounts.social_media(
name text,
platform text,
url text,
time_created timestamp,
PRIMARY KEY ((name), platform, time_created)
);

INSERT INTO accounts.social_media
(name, platform, url, time_created)
VALUES ('Lee Quan', 'Facebook', 'www.facebook.com/leequan', toTimeStamp(now()));

INSERT INTO accounts.social_media
(name, platform, url, time_created)
VALUES ('Lee Quan', 'Facebook', 'www.facebook.com/leequan2', toTimeStamp(now()));

INSERT INTO accounts.social_media
(name, platform, url, time_created)
VALUES ('Lee Quan', 'LinkedIn', 'www.linkedin.com/leequan', toTimeStamp(now()));

INSERT INTO accounts.social_media
(name, platform, url, time_created)
VALUES ('Kang Yee', 'LinkedIn', 'www.linkedin.com/kangyee', toTimeStamp(now()));

INSERT INTO accounts.social_media
(name, platform, url, time_created)
VALUES ('Kang Yee', 'YouTube', 'www.youtube.com/kangyee', toTimeStamp(now()));

INSERT INTO accounts.social_media
(name, platform, url, time_created)
VALUES ('Kang Yee', 'YouTube', 'www.youtube.com/kangyee2', toTimeStamp(now()));

INSERT INTO accounts.social_media
(name, platform, url, time_created)
VALUES ('Liang Han', 'Facebook', 'www.facebook.com/lianghan', toTimeStamp(now()));

INSERT INTO accounts.social_media
(name, platform, url, time_created)
VALUES ('Liang Han', 'Facebook', 'www.facebook.com/lianghan2', toTimeStamp(now()));

INSERT INTO accounts.social_media
(name, platform, url, time_created)
VALUES ('Liang Han', 'Facebook', 'www.facebook.com/lianghan3', toTimeStamp(now()));

INSERT INTO accounts.social_media
(name, platform, url, time_created)
VALUES ('Liang Han', 'Reddit', 'www.reddit.com/u/lianghan', toTimeStamp(now()));

INSERT INTO accounts.social_media
(name, platform, url, time_created)
VALUES ('Liang Han', 'Reddit', 'www.reddit.com/u/lianghan2', toTimeStamp(now()));
