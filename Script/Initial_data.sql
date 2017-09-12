declare @vYear nvarchar(4) = '2560'
declare @vUser nvarchar(50) = 'import'
declare @vDirector_code nvarchar(50) = 'H6003'

BEGIN TRANSACTION

INSERT INTO [mju_budget].[dbo].[Budget]
           ([budget_code]
           ,[budget_year]
           ,[budget_name]
		   ,budget_type
           ,[c_active]
           ,[c_created_by]
           ,[d_created_date])
	SELECT [budget_code]
		  ,[budget_year]
		  ,[budget_name]
		  ,budget_type
		  ,[c_active]
		  ,@vUser
		  ,getdate()
FROM [mju_payroll].[dbo].[Budget] 
WHERE [budget_year] = @vYear ;


-- Produce
INSERT INTO [mju_budget].[dbo].[Produce]
           ([produce_code]
           ,[produce_year]
           ,[produce_name]
           ,[budget_code]
           ,[c_active]
           ,[c_created_by]
           ,[d_created_date]
           ,[produce_sort_name]
           ,[project_code]
           ,[budget_type])
SELECT		[produce_code]
           ,[produce_year]
           ,[produce_name]
           ,[budget_code]
           ,[c_active]
           ,@vUser
           ,getdate()
           ,[produce_sort_name]
           ,[project_code]
           ,[budget_type]
FROM [mju_payroll].[dbo].[Produce]
WHERE [produce_year] = @vYear ;



INSERT INTO [mju_budget].[dbo].[Activity]
           ([activity_code]
           ,[activity_year]
           ,[activity_name]
           ,[produce_code]
		   ,budget_type
           ,[c_active]
           ,[c_created_by]
           ,[d_created_date])
Select		[activity_code]
           ,[activity_year]
           ,[activity_name]
           ,[produce_code]
		   ,budget_type
           ,[c_active]
           ,@vUser
           ,getdate()
FROM [mju_payroll].[dbo].[Activity]
WHERE [activity_year] = @vYear ;


-- Level_position

INSERT INTO [mju_budget].[dbo].[level_position]
           ([level_position_code]
           ,[level_position_name]
           ,[c_active]
           ,[c_created_by]
           ,[d_created_date])
 SELECT  [level_position_code]
           ,[level_position_name]
           ,[c_active]
		   ,@vUser
           ,getdate()
FROM [mju_payroll].[dbo].[level_position] ;

-- Lot

INSERT INTO  [mju_budget].[dbo].[lot]
           ([lot_code]
           ,[lot_year]
           ,[lot_name]
           ,[c_active]
           ,[c_created_by]
           ,[d_created_date]
           ,[budget_type])
SELECT     [lot_code]
           ,[lot_year]
           ,[lot_name]
           ,[c_active]
		   ,@vUser
           ,getdate()
           ,[budget_type]
FROM [mju_payroll].[dbo].[lot]
WHERE [lot_year] = @vYear ;


-- Person_group
INSERT INTO [mju_budget].[dbo].[Person_group]
           ([person_group_code]
           ,[person_group_name]
           ,[c_active]
           ,[c_created_by]
           ,[d_created_date])
SELECT		[person_group_code]
		   ,[person_group_name]
           ,[c_active]
		   ,@vUser
           ,getdate()
FROM [mju_payroll].[dbo].[Person_group] ;


-- Work
INSERT INTO [mju_budget].[dbo].[Work]
           ([work_code]
           ,[work_year]
           ,[work_name]
           ,[c_active]
           ,[c_created_by]
           ,[d_created_date]
           ,[budget_type])
SELECT		[work_code]
           ,[work_year]
           ,[work_name]
           ,[c_active]
           ,@vUser
           ,getdate()
           ,[budget_type]
FROM [mju_payroll].[dbo].[Work] 
WHERE [work_year] = @vYear ;


-- Person_manage
INSERT INTO [mju_budget].[dbo].[Person_manage]
           ([person_manage_code]
           ,[person_manage_name]
           ,[c_active]
           ,[c_created_by]
           ,[d_created_date])
SELECT		[person_manage_code]
           ,[person_manage_name]
           ,[c_active]
           ,@vUser
           ,getdate()
FROM [mju_payroll].[dbo].[Person_manage];


-- Person_work_status
INSERT INTO [mju_budget].[dbo].[Person_work_status]
           ([person_work_status_code]
           ,[person_work_status_name]
           ,[c_active]
           ,[c_created_by]
           ,[d_created_date])
SELECT      [person_work_status_code]
           ,[person_work_status_name]
           ,[c_active]
           ,@vUser
           ,getdate()
FROM [mju_payroll].[dbo].[Person_work_status] ;

-- Plan
INSERT INTO [mju_budget].[dbo].[Plan]
           ([plan_code]
           ,[plan_year]
           ,[plan_name]
           ,[c_active]
           ,[c_created_by]
           ,[d_created_date]
           ,[budget_type])
 SELECT		[plan_code]
           ,[plan_year]
           ,[plan_name]
           ,[c_active]
           ,@vUser
           ,getdate()
           ,[budget_type]
FROM [mju_payroll].[dbo].[Plan]
WHERE [plan_year] = @vYear ;

-- Position
INSERT INTO [mju_budget].[dbo].[Position]
           ([position_code]
           ,[position_name]
           ,[c_active]
           ,[c_created_by]
           ,[d_created_date])
SELECT		[position_code]
           ,[position_name]
           ,[c_active]
           ,@vUser
           ,getdate()
FROM [mju_payroll].[dbo].[Position]


-- Title
INSERT INTO [mju_budget].[dbo].[Title]
           ([title_code]
           ,[title_name]
           ,[c_active]
           ,[c_created_by]
           ,[d_created_date])
SELECT		[title_code]
           ,[title_name]
           ,[c_active]
           ,@vUser
           ,getdate()
FROM [mju_payroll].[dbo].[Title] ;

-- Type_position
INSERT INTO [mju_budget].[dbo].[Type_position]
           ([type_position_code]
           ,[type_position_name]
           ,[c_active]
           ,[c_created_by]
           ,[d_created_date])
SELECT		[type_position_code]
           ,[type_position_name]
           ,[c_active]
           ,@vUser
           ,getdate()
FROM [mju_payroll].[dbo].[Type_position];


-- Fund
INSERT INTO [mju_budget].[dbo].[Fund]
           ([fund_code]
           ,[fund_year]
           ,[fund_name]
           ,[c_active]
           ,[c_created_by]
           ,[d_created_date]           
           ,[budget_type])
SELECT		[fund_code]
           ,[fund_year]
           ,[fund_name]
           ,[c_active]
           ,@vUser
           ,getdate()  
           ,[budget_type]
FROM [mju_payroll].[dbo].[Fund] 
WHERE [fund_year] = @vYear ;

-- Director
INSERT INTO [mju_budget].[dbo].[Director]
           ([director_code]
           ,[director_year]
           ,[director_name]
           ,[c_active]
           ,[c_created_by]
           ,[d_created_date]
           ,[budget_type])
SELECT		[director_code]
           ,[director_year]
           ,[director_name]
           ,[c_active]
           ,@vUser
           ,getdate()
           ,[budget_type]
FROM  [mju_payroll].[dbo].[Director]
WHERE director_year = @vYear 
AND	  director_code = @vDirector_code ;

-- Unit
INSERT INTO [mju_budget].[dbo].[unit]
           ([unit_code]
           ,[unit_year]
           ,[unit_name]
           ,[director_code]
           ,[c_active]
           ,[c_created_by]
           ,[d_created_date]
           ,[budget_type])
SELECT		[unit_code]
           ,[unit_year]
           ,[unit_name]
           ,[director_code]
           ,[c_active]
           ,@vUser
           ,getdate()
           ,[budget_type]
FROM [mju_payroll].[dbo].[unit]
WHERE [unit_year] = @vYear 
AND   director_code = @vDirector_code ;

-- Budget_plan
INSERT INTO [mju_budget].[dbo].[Budget_plan]
           ([budget_plan_code]
           ,[budget_plan_year]
           ,[unit_code]
           ,[activity_code]
           ,[plan_code]
           ,[work_code]
           ,[fund_code]
           ,[c_active]
           ,[c_created_by]
           ,[d_created_date]
           ,[budget_type])
SELECT		[budget_plan_code]
           ,[budget_plan_year]
           ,[unit_code]
           ,[activity_code]
           ,[plan_code]
           ,[work_code]
           ,[fund_code]
           ,[c_active]
           ,@vUser
           ,getdate()
           ,[budget_type]
FROM  [mju_payroll].[dbo].[view_Budget_plan]
WHERE [budget_plan_year] = @vYear 
AND   director_code = @vDirector_code ;


-- Person_his
INSERT INTO [mju_budget].[dbo].[Person_his]
           ([person_code]
           ,[title_code]
           ,[person_thai_name]
           ,[person_thai_surname]
           ,[person_eng_name]
           ,[person_eng_surname]
           ,[person_nickname]
           ,[person_id]
           ,[person_pic]
           ,[c_active]
           ,[c_created_by]
           ,[d_created_date])
SELECT		[person_code]
           ,[title_code]
           ,[person_thai_name]
           ,[person_thai_surname]
           ,[person_eng_name]
           ,[person_eng_surname]
           ,[person_nickname]
           ,[person_id]
           ,[person_pic]
           ,[c_active]
           ,@vUser
           ,getdate()
FROM  [mju_payroll].[dbo].[view_person_all]
WHERE [budget_plan_year] = @vYear 
AND   director_code = @vDirector_code ;


update person_work set person_manage_code = null
where person_manage_code not in (select person_manage_code from person_manage);

update person_work set type_position_code = null
where type_position_code not in (select type_position_code from type_position) ;

-- Person_work
INSERT INTO [mju_budget].[dbo].[Person_work]
           ([person_code]
           ,[position_code]
           ,[person_level]
           ,[person_postionno]
           ,[person_start]
           ,[person_end]
           ,[person_group_code]
           ,[person_manage_code]
           ,[budget_plan_code]
           ,[person_work_status_code]
           ,[type_position_code]
           ,[person_budget_type]
           ,[user_group_list]
           ,[major_code]
           ,[c_created_by]
           ,[d_created_date])
 SELECT [person_code]
           ,[position_code]
           ,[person_level]
           ,[person_postionno]
           ,[person_start]
           ,[person_end]
           ,[person_group_code]
           ,[person_manage_code]
           ,[budget_plan_code]
           ,[person_work_status_code]
           ,[type_position_code]
           ,[person_budget_type]
           ,null
           ,null
           ,@vUser
           ,getdate()
FROM  [mju_payroll].[dbo].[view_person_all] 
WHERE [budget_plan_year] = @vYear 
AND   director_code = @vDirector_code ;


IF @@ERROR <> 0
BEGIN
	-- Rollback the transaction
	ROLLBACK TRANSACTION
	Return
END
COMMIT

