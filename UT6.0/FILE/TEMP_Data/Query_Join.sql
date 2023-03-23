use HRDB2

--1 inner Join
--�⺻Ű�� �ܷ� Ű ���� ��ġ�ϴ� �ุ ��� 
--2. Left Outer Join, Right Outer Join, Full Outer Join
-- 2014��,2015�⿡ �Ի��ؼ� ���� �ٹ� ���� ������ ������ �μ� �̸��� �����ؼ� ��ȸ
Select e.EmpID, e.EmpName, e.DeptID, d.DeptName, e.Phone, e.Email
From dbo.Employee as e
Inner Join dbo.department as d ON e.deptID = d.DeptID
Where e.HireDate Between '2014-01-01' And '2015-12-31'
and RetireDate IS NULL

Go

-- 2015��, 2016�⿡ �Ի��ؼ� ���� �ٹ����� ������ �� �ް��� �� ����
-- �ִ� ������ �ް� ��Ȳ�� ��ȸ�ϴ� ������. �ް��� �� ���� ����
-- ����� ��Ÿ���� �ʴ´�.
select e.empID, e.empName, v.BeginDate, v.enddate, v.Reason, v.Duration
From dbo.Employee AS e
inner Join dbo.Vacation as v ON e.EmpID = v.EmpID
Where e.HireDate between '2015-01-01' And '2016-12-31'
  And RetireDate IS NULL
  order by e.EmpID ASC


  --2 OUTER Join
  -- 2015,2016�� �Ի��ؼ� ���� �ٹ� ���� �������� �ް� ��Ȳ�� ��ȸ
  -- �ް��� �� ���� ���� ������ ����� ��Ÿ��

  select e.empid, e.empname, v.begindate, v.enddate, v.reason, v.duration
  from employee as e
  Left Outer Join vacation as v ON e.empid =v.EmpID
  where e.HireDate between '2015-01-01' and '2016-12-31'
  And RetireDate is null
  order by e.EmpID asc

  -- ���� �̸��� �����ؼ� ��� �μ� ���� ��ȸ
  Select d.deptID, d.deptName, d.UnitID, u.UnitName
  From Department as d
  Left outer join Unit as u on d.UnitID = u.UnitID
  go

  -- 3 ���� ���̺��� Join��
  -- 2016�� 1�б� �ް��� �� �������� �ް� ��Ȳ�� �μ� �̸��� ���� �̸� ���� ��ȸ
  Select e.empID, e.empName, d.DeptName, u.UnitName,
         v.BeginDate, v.EndDate, v.Duration
  From employee as e
  inner join dbo.Department AS d ON e.DeptID = d.DeptID
  Left outer join unit as u on  d.UnitID = u.UnitID
  inner join Vacation as v on e.EmpID = v.EmpID
  Where v.BeginDate between '2016-01-01' and '2016-03-31'
  order by e.empID ASC