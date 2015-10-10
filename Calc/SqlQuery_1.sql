SET NOCOUNT ON

declare @amounts TABLE
(
       Id     INT    IDENTITY(1,1)
       , Amount      FLOAT
       , DT   DATE primary key
)

-- 2011
INSERT INTO @amounts( Amount, DT )      SELECT 324, '2011-09-10'
INSERT INTO @amounts( Amount, DT )      SELECT 360, '2011-09-22'
INSERT INTO @amounts( Amount, DT )      SELECT 324, '2011-10-04'
INSERT INTO @amounts( Amount, DT )      SELECT 324, '2011-10-14'
INSERT INTO @amounts( Amount, DT )      SELECT 324, '2011-10-21'
INSERT INTO @amounts( Amount, DT )      SELECT 288, '2011-11-06'
INSERT INTO @amounts( Amount, DT )      SELECT 304, '2011-11-13'
INSERT INTO @amounts( Amount, DT )      SELECT 288, '2011-11-19'
INSERT INTO @amounts( Amount, DT )      SELECT 304, '2011-11-26'
INSERT INTO @amounts( Amount, DT )      SELECT 288, '2011-12-02'
INSERT INTO @amounts( Amount, DT )      SELECT 272, '2011-12-07'
INSERT INTO @amounts( Amount, DT )      SELECT 160, '2011-12-12'
INSERT INTO @amounts( Amount, DT )      SELECT 240, '2011-12-14'
INSERT INTO @amounts( Amount, DT )      SELECT 272, '2011-12-19'
INSERT INTO @amounts( Amount, DT )      SELECT 288, '2011-12-24'
INSERT INTO @amounts( Amount, DT )      SELECT 288, '2011-12-29'
-- 2012
INSERT INTO @amounts( Amount, DT )      SELECT 272, '2012-01-03'
INSERT INTO @amounts( Amount, DT )      SELECT 304, '2012-01-08'
INSERT INTO @amounts( Amount, DT )      SELECT 352, '2012-01-13'
INSERT INTO @amounts( Amount, DT )      SELECT 240, '2012-01-18'
INSERT INTO @amounts( Amount, DT )      SELECT 288, '2012-01-23'
INSERT INTO @amounts( Amount, DT )      SELECT 240, '2012-01-27'
INSERT INTO @amounts( Amount, DT )      SELECT 128, '2012-01-29'
INSERT INTO @amounts( Amount, DT )      SELECT 288, '2012-02-02'
INSERT INTO @amounts( Amount, DT )      SELECT 288, '2012-02-06'
INSERT INTO @amounts( Amount, DT )      SELECT 272, '2012-02-09'
INSERT INTO @amounts( Amount, DT )      SELECT 128, '2012-02-11'
INSERT INTO @amounts( Amount, DT )      SELECT 272, '2012-02-14'
INSERT INTO @amounts( Amount, DT )      SELECT 256, '2012-02-18'
INSERT INTO @amounts( Amount, DT )      SELECT 240, '2012-02-22'
INSERT INTO @amounts( Amount, DT )      SELECT 112, '2012-02-25'
INSERT INTO @amounts( Amount, DT )      SELECT 224, '2012-02-29'
INSERT INTO @amounts( Amount, DT )      SELECT 224, '2012-03-05'
INSERT INTO @amounts( Amount, DT )      SELECT 256, '2012-03-14'
INSERT INTO @amounts( Amount, DT )      SELECT 256, '2012-03-20'
INSERT INTO @amounts( Amount, DT )      SELECT 224, '2012-03-26'
INSERT INTO @amounts( Amount, DT )      SELECT 224, '2012-04-01'
INSERT INTO @amounts( Amount, DT )      SELECT 224, '2012-04-06'
INSERT INTO @amounts( Amount, DT )      SELECT 240, '2012-04-10'
INSERT INTO @amounts( Amount, DT )      SELECT 256, '2012-04-17'
INSERT INTO @amounts( Amount, DT )      SELECT 240, '2012-04-24'
INSERT INTO @amounts( Amount, DT )      SELECT 240, '2012-05-02'
INSERT INTO @amounts( Amount, DT )      SELECT 272, '2012-05-12'
INSERT INTO @amounts( Amount, DT )      SELECT 256, '2012-05-24'
INSERT INTO @amounts( Amount, DT )      SELECT 256, '2012-06-06'
INSERT INTO @amounts( Amount, DT )      SELECT 160, '2012-06-19'
INSERT INTO @amounts( Amount, DT )      SELECT 80,  '2012-07-02'
-- change graph and set total to 0
INSERT INTO @amounts( Amount, DT )      SELECT 208, '2012-08-28'
INSERT INTO @amounts( Amount, DT )      SELECT 256, '2012-09-08'
INSERT INTO @amounts( Amount, DT )      SELECT 272, '2012-09-22'
INSERT INTO @amounts( Amount, DT )      SELECT 224, '2012-09-30'
INSERT INTO @amounts( Amount, DT )      SELECT 288, '2012-10-08'
INSERT INTO @amounts( Amount, DT )      SELECT 240, '2012-10-15'
INSERT INTO @amounts( Amount, DT )      SELECT 208, '2012-10-21'
INSERT INTO @amounts( Amount, DT )      SELECT 240, '2012-10-27'
INSERT INTO @amounts( Amount, DT )      SELECT 256, '2012-11-01'
INSERT INTO @amounts( Amount, DT )      SELECT 256, '2012-11-07'
INSERT INTO @amounts( Amount, DT )      SELECT 256, '2012-11-13'
INSERT INTO @amounts( Amount, DT )      SELECT 320, '2012-11-20'
INSERT INTO @amounts( Amount, DT )      SELECT 240, '2012-11-25'
INSERT INTO @amounts( Amount, DT )      SELECT 288, '2012-12-01'
INSERT INTO @amounts( Amount, DT )      SELECT 256, '2012-12-05'
INSERT INTO @amounts( Amount, DT )      SELECT 208, '2012-12-09'
INSERT INTO @amounts( Amount, DT )      SELECT 288, '2012-12-13'
INSERT INTO @amounts( Amount, DT )      SELECT 288, '2012-12-18'
INSERT INTO @amounts( Amount, DT )      SELECT 288, '2012-12-23'
INSERT INTO @amounts( Amount, DT )      SELECT 288, '2012-12-28'
-- 2013
INSERT INTO @amounts( Amount, DT )      SELECT 272, '2013-01-02'
INSERT INTO @amounts( Amount, DT )      SELECT 272, '2013-01-07'
INSERT INTO @amounts( Amount, DT )      SELECT 256, '2013-01-12'
INSERT INTO @amounts( Amount, DT )      SELECT 272, '2013-01-16'
INSERT INTO @amounts( Amount, DT )      SELECT 256, '2013-01-20'
INSERT INTO @amounts( Amount, DT )      SELECT 304, '2013-01-25'
INSERT INTO @amounts( Amount, DT )      SELECT 240, '2013-01-28'
INSERT INTO @amounts( Amount, DT )      SELECT 272, '2013-02-02'
INSERT INTO @amounts( Amount, DT )      SELECT 272, '2013-02-06'
INSERT INTO @amounts( Amount, DT )      SELECT 272, '2013-02-11'
INSERT INTO @amounts( Amount, DT )      SELECT 208, '2013-02-14'
INSERT INTO @amounts( Amount, DT )      SELECT 240, '2013-02-18'

03-12-2013	270
07-12-2013	210
12-12-2013	240
17-12-2013	270
23-12-2013	270
28-12-2013	255
02-01-2014	270
07-01-2014	270
12-01-2014	225
17-01-2014	270
21-01-2014	240
25-01-2014	255
28-01-2014	240
01-02-2014	255
06-02-2014	270
11-02-2014	270
16-02-2014	255
21-02-2014	255
26-02-2014	225
04-03-2014	270
09-03-2014	240
16-03-2014	270
23-03-2014	300
30-03-2014	300
06-04-2014	285
12-04-2014	225
19-04-2014	270
03-05-2014	300
11-05-2014	180
17-08-2014	240
10-09-2014	240
26-09-2014	225
01-10-2014	135
11-10-2014	255
20-10-2014	255
28-10-2014	255
05-11-2014	255
14-11-2014	270
18-11-2014	240
23-11-2014	210
29-11-2014	304
04-12-2014	272
09-12-2014	272
14-12-2014	255
18-12-2014	300
23-12-2014	255
28-12-2014	315
01-01-2015	240
05-01-2015	285
09-01-2015	240
13-01-2015	240
17-01-2015	255
21-01-2015	255
25-01-2015	255
29-01-2015	285
06-02-2015	255
10-02-2015	270
14-02-2015	225
14-02-2015	225
21-02-2015	240
25-02-2015	285
01-03-2015	255
06-03-2015	255
11-03-2015	255
16-03-2015	240
21-03-2015	210
26-03-2015	270
31-03-2015	240
05-04-2015	270
11-04-2015	240
17-04-2015	270
24-04-2015	240
01-05-2015	255
08-05-2015	285
18-05-2015	240
27-05-2015	240
03-06-2015	240
27-06-2015	255


SELECT SUM(Amount) FROM @amounts
where DT < '2012-08-28'
--SELECT COUNT(*) FROM @amounts

--SELECT * FROM @amounts order by Id

declare @rows TABLE
(
       Id     INT
       , Amount      FLOAT
       , FromDate    DATE
       , ToDate      DATE
       , DaysInPeriod AS (DATEDIFF(d, FromDate, ToDate) + 1 ) -- ajust for the missing day when we did the ToDate - 1 day
       , AmountPrDay AS (Amount / (DATEDIFF(d, FromDate, ToDate) + 1) )
)

INSERT INTO @rows
	SELECT
		a.Id
		, a.Amount
		, (    SELECT TOP 1 b.DT
						FROM @amounts b
						WHERE b.DT < a.DT
						ORDER BY b.DT DESC) AS FromDate
		, DATEADD(d, -1, a.DT) AS ToDate
	FROM
		@amounts a
	ORDER BY a.DT ASC


IF ( EXISTS(SELECT *
	FROM @rows
	WHERE DaysInPeriod = 0))
	BEGIN
		PRINT 'One or more rows have Zero days in the period between FromDate and ToDate, after ajusting the FromDate to begin one day after the ToDate from the previous period. This wil result in Division by zero exception. Please merge the row with the amount for the next period.'
		SELECT *
			FROM @rows
			WHERE DaysInPeriod = 0
	END


SELECT
       r.*
       FROM @rows r
       WHERE r.FromDate IS NOT NULL

-- Generate rows by the day using avarage amounts
declare @currentdate date
declare @maxdate     date

       select @currentdate = MIN(r.FromDate)
              from @rows r
              WHERE r.FromDate IS NOT NULL

       select @maxdate = MAX(r.ToDate)
              from @rows r

       DECLARE @daylyRows TABLE
       (
              Id     INT
              , dates       DATE
              , amounts     FLOAT
              , total       FLOAT
       )

       declare @total       float = 0

       WHILE(@currentdate <= @maxdate)
       BEGIN
		
			IF ( @currentdate = '2012-08-28' )
			BEGIN
				SET @total = 0 -- new heading period starts
			END
			-- accumulate amount over time
			SELECT @total += r.AmountPrDay
					FROM @rows r
					WHERE @currentdate between r.FromDate AND r.ToDate

			-- create one row pr day
			INSERT INTO @daylyRows (Id, dates, amounts, total)
					SELECT r.Id, @currentdate, r.AmountPrDay, @total
					FROM @rows r
					WHERE @currentdate between r.FromDate AND r.ToDate

			-- move one day forward
			SET @currentdate = DATEADD(d, 1, @currentdate)

       END

       SELECT r.Id ,
              r.dates ,
              r.amounts ,
              CONVERT(INT, r.total) AS total
              FROM @daylyRows r
              ORDER BY r.dates, id asc
