Use Net Core C# or Python for your implementation.
We will evaluate your skills in object-oriented programming and design.
We expect the code to be production-quality, and can easily be maintained and evolved, not just a barebones
algorithm.
It would be a plus if you would have docker file in your solution as well.
Commit your solution to https://github.com/.
# Programming Challenge
The Wikimedia Foundation provides all pageviews for Wikipedia site since 2015 in machine-readable format.
The pageviews can be downloaded in gzip format and are aggregated per hour per page. Each hourly dump is
approximately 50MB in gzipped text file and is somewhere between 100MB and 250MB in size unzipped.
- File’s location: https://dumps.wikimedia.org/other/pageviews/
- Sample file: https://dumps.wikimedia.org/other/pageviews/2015/2015-05/pageviews-20150501-010000.gz
- Technical documentation: https://wikitech.wikimedia.org/wiki/Analytics/Data_Lake/Traffic/Pageviews
# Task
- Create a command line application
- Get data for last 5 hours
- Calculate by the code the following SQL statement
- ALL_HOURS table represent all files
- SQL statement use just to provide you requirements do not use database in your solution.

SELECT TOP 100 DOMAIN_CODE, PAGE_TITLE, SUM (count_views) CNT
FROM ALL_HOURS
GROUP BY DOMAIN_CODE, PAGE_TITLE
ORDER BY SUM (cont_views) DESC

- DOMAIN_CODE PAGE_TITEL CNT
- it.m renault 100000
- en apple 50000
- fr.m.d relativité 3000
- it.m bongur 2000

# Wiki Challenge
# Architecture
CQRS. C# Net Core 3.1
# Rest "/api/Wiki/GetData" will show the results
Top 100 and grouped in descending order
