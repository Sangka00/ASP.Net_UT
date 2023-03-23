use HRDB2

--1 inner Join
--기본키와 외래 키 열에 일치하는 행만 결과 
--2. Left Outer Join, Right Outer Join, Full Outer Join
-- 2014년,2015년에 입사해서 현재 근무 중인 직원들 정보를 부서 이름을 포함해서 조회
Select e.EmpID, e.EmpName, e.DeptID, d.DeptName, e.Phone, e.Email
From dbo.Employee as e
Inner Join dbo.department as d ON e.deptID = d.DeptID
Where e.HireDate Between '2014-01-01' And '2015-12-31'
and RetireDate IS NULL

Go

-- 2015년, 2016년에 입사해서 현재 근무중인 직원들 중 휴가를 간 적이
-- 있는 직원의 휴가 현황을 조회하는 쿼리문. 휴가를 간 적이 없는
-- 결과에 나타나지 않는다.
select e.empID, e.empName, v.BeginDate, v.enddate, v.Reason, v.Duration
From dbo.Employee AS e
inner Join dbo.Vacation as v ON e.EmpID = v.EmpID
Where e.HireDate between '2015-01-01' And '2016-12-31'
  And RetireDate IS NULL
  order by e.EmpID ASC


  --2 OUTER Join
  -- 2015,2016년 입사해서 현재 근무 중인 직원들의 휴가 현황을 조회
  -- 휴가를 간 적이 없는 직원도 결과에 나타남

  select e.empid, e.empname, v.begindate, v.enddate, v.reason, v.duration
  from employee as e
  Left Outer Join vacation as v ON e.empid =v.EmpID
  where e.HireDate between '2015-01-01' and '2016-12-31'
  And RetireDate is null
  order by e.EmpID asc

  -- 본부 이름을 포함해서 모든 부서 정보 조회
  Select d.deptID, d.deptName, d.UnitID, u.UnitName
  From Department as d
  Left outer join Unit as u on d.UnitID = u.UnitID
  go

  -- 3 여러 테이블간의 Join문
  -- 2016년 1분기 휴가를 간 직원들의 휴가 현황을 부서 이름과 본부 이름 포함 조회
  Select e.empID, e.empName, d.DeptName, u.UnitName,
         v.BeginDate, v.EndDate, v.Duration
  From employee as e
  inner join dbo.Department AS d ON e.DeptID = d.DeptID
  Left outer join unit as u on  d.UnitID = u.UnitID
  inner join Vacation as v on e.EmpID = v.EmpID
  Where v.BeginDate between '2016-01-01' and '2016-03-31'
  order by e.empID ASC