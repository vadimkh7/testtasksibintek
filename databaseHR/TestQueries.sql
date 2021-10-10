--1 QUERY Selecting first hired employee

SELECT FIRST_NAME, LAST_NAME, HIRE_DATE FROM EMPLOYEES
WHERE HIRE_DATE = (SELECT MIN(HIRE_DATE) FROM EMPLOYEES)

--2 QUERY Selecting which region has biggest department accroding to number of employees

SELECT COUNT(EMPLOYEES.EMPLOYEE_ID) AS [Number of empl], DEPARTMENTS.DEPARTMENT_ID, REGION_NAME FROM DEPARTMENTS
INNER JOIN LOCATIONS ON  DEPARTMENTS.LOCATION_ID = LOCATIONS.LOCATION_ID
INNER JOIN COUNTRIES ON  LOCATIONS.COUNTRY_ID = COUNTRIES.COUNTRY_ID
INNER JOIN REGIONS ON COUNTRIES.REGION_ID = REGIONS.REGION_ID
INNER JOIN EMPLOYEES ON DEPARTMENTS.DEPARTMENT_ID = EMPLOYEES.DEPARTMENT_ID
WHERE DEPARTMENTS.DEPARTMENT_ID = 
	(SELECT DEPARTMENT_ID as id FROM 
								(SELECT DEPARTMENT_ID, COUNT(EMPLOYEE_ID) AS [cnt] FROM EMPLOYEES GROUP BY DEPARTMENT_ID) AS A
	WHERE CNT = (SELECT MAX(CNT) FROM 
								(SELECT DEPARTMENT_ID, COUNT(EMPLOYEE_ID) AS [cnt] FROM EMPLOYEES GROUP BY DEPARTMENT_ID) as B)
)
GROUP BY DEPARTMENTS.DEPARTMENT_ID, REGION_NAME

--3 QUERY Avrage salary based on department


SELECT DEPARTMENT_ID, AVG(SALARY) AS [AVG SALARY] FROM EMPLOYEES
GROUP BY DEPARTMENT_ID

--4 QUERY Selecting list of regions with employee count and avrage salary
SELECT REGIONS.REGION_NAME, COUNT(EMPLOYEE_ID) AS [COUNT_EMP], AVG(SALARY) AS [Avg salary] FROM EMPLOYEES
INNER JOIN DEPARTMENTS ON EMPLOYEES.DEPARTMENT_ID = DEPARTMENTS.DEPARTMENT_ID
INNER JOIN LOCATIONS ON  DEPARTMENTS.LOCATION_ID = LOCATIONS.LOCATION_ID
INNER JOIN COUNTRIES ON  LOCATIONS.COUNTRY_ID = COUNTRIES.COUNTRY_ID
INNER JOIN REGIONS ON COUNTRIES.REGION_ID = REGIONS.REGION_ID
GROUP BY REGION_NAME

--5 QUERY inreascing salary of amerecans employees by 20%

UPDATE EMPLOYEES 
SET SALARY = 1.2 * SALARY
WHERE EMPLOYEE_ID IN (
SELECT EMPLOYEE_ID FROM EMPLOYEES
INNER JOIN DEPARTMENTS ON EMPLOYEES.DEPARTMENT_ID = DEPARTMENTS.DEPARTMENT_ID
INNER JOIN LOCATIONS ON  DEPARTMENTS.LOCATION_ID = LOCATIONS.LOCATION_ID
INNER JOIN COUNTRIES ON  LOCATIONS.COUNTRY_ID = COUNTRIES.COUNTRY_ID
WHERE REGION_ID = 5)


