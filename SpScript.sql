

CREATE PROCEDURE [dbo].[StudentSave]
	@Json				NVARCHAR(MAX)
	,	@RetVal			INT OUTPUT
	,	@DataType		INT	OUTPUT
	,	@ErrorNumber	INT	OUTPUT
	,	@ErrorMessage	NVARCHAR(2000)	OUTPUT
	,	@JsonOutput		NVARCHAR(MAX)	=	NULL	OUTPUT 
AS
BEGIN

	SET NOCOUNT ON;

	/* 
		Keep these values global
		Return Values
		 -2		-	Concurrency	Issue
		 -1		-	Record Not Found
		  0		-	No Error (Default Value)
		> 0		-	Record ID
	*/

	DECLARE		@ID				INT
	DECLARE		@DepartmentId	INT
	DECLARE		@Email			VARCHAR(200)
	DECLARE		@Name			VARCHAR(200)
	DECLARE		@Password			VARCHAR(200)
	DECLARE		@Phone			VARCHAR(200)
	DECLARE		@RollId			INT



	

	SET @RetVal					=	0;	
	/*
		@DataType
			0	Scalar
			1	Grid
			2	Json
	*/
	SET @DataType				=	0;	
	/*
		-1	Invalid Parameter
	*/
	SET @ErrorNumber			=	0;

	BEGIN TRY

	SELECT
			@ID					=	[ID]					
			,	@DepartmentId	=	[DepartmentId]		
			,	@Email			=	[Email]				
			,	@Name			=	[Name]				
			,	@Password		=	[Password]			
			,	@Phone			=	[Phone]				
			,	@RollId			=	[RollId]			
		FROM  OPENJSON(@Json)
		WITH
		(
			[ID]					INT			N'$.id'
		,	[DepartmentId]		INT				N'$.DepartmentId'
		,	[Email]				VARCHAR(200)	N'$.Email'
		,	[Name]				VARCHAR(200)	N'$.Name'
		,	[Password]			VARCHAR(200)	N'$.Password'
		,	[Phone]				VARCHAR(200)	N'$.Phone'
		,	[RollId]			INT				N'$.RollId'
			
		)
	
			
		IF @ID	=	0	OR	@ID IS NULL
		BEGIN

INSERT INTO [dbo].[User]
           ([Phone]
           ,[Password]
           ,[Name]
           ,[DepartmentId]
           ,[Email]
           ,[RollId])
		
		SELECT
			@Phone
		   ,	@Password
		   ,	@Name
		   ,	@DepartmentId
		   ,	@Email
		   ,	@RollId

		SET @RetVal = SCOPE_IDENTITY()
		END
		ELSE 
		BEGIN
			UPDATE [dbo].[User]
				SET	[Phone]					=	@Phone
					,	[Password]			=		@Password
					,	[Name]				=		@Name
					,	[DepartmentId]		=		@DepartmentId
					,	[Email]				=		@Email
					,	[RollId]			=		@RollId
			SET @RetVal = @ID
		END

	SET		@DataType = 0
END TRY
	BEGIN CATCH
		/* Invalid parameter error */
		SET @ErrorNumber = -1;
		SET	@ErrorMessage	=	ERROR_MESSAGE();
	END  CATCH
END

GO
CREATE PROCEDURE [dbo].[StudentDetails]
	@Json				NVARCHAR(MAX)
	,	@RetVal			INT OUTPUT
	,	@DataType		INT	OUTPUT
	,	@ErrorNumber	INT	OUTPUT
	,	@ErrorMessage	NVARCHAR(2000)	OUTPUT
	,	@JsonOutput		NVARCHAR(MAX)	=	NULL	OUTPUT 
AS
BEGIN

	SET NOCOUNT ON;

	/* 
		Keep these values global
		Return Values
		 -2		-	Concurrency	Issue
		 -1		-	Record Not Found
		  0		-	No Error (Default Value)
		> 0		-	Record ID
	*/
	DECLARE	@StartPage			INT
	DECLARE		@SearchText		NVARCHAR(500)
	DECLARE		@PageNumber		INT
	DECLARE		@PageSize		INT
	DECLARE		@SortOrder		INT
	DECLARE		@SortDir		INT
	DECLARE		@FilteredCount	INT
	DECLARE		@ID				INT

	SET @RetVal					=	0;	
	/*
		@DataType
			0	Scalar
			1	Grid
			2	Json
	*/
	SET @DataType				=	0;	
	/*
		-1	Invalid Parameter
	*/
	SET @ErrorNumber			=	0;

	BEGIN TRY

	SELECT
			@PageNumber						=	NULLIF([PageNumber],0)
			,	@PageSize					=	NULLIF([PageSize],0)
			,	@SortOrder					=	[SortOrder]
			,	@SortDir					=	[SortDir]
			,	@SearchText					=	NULLIF([SearchText],'')
			,	@ID							=	[ID]
		FROM  OPENJSON(@Json)
		WITH
		(
			[PageNumber]		INT				N'$.PageNumber'
			,	[PageSize]		INT				N'$.PageSize'
			,	[SortOrder]		INT				N'$.SortOrder'
			,	[SortDir]		INT				N'$.SortDir'
			,	[SearchText]	NVARCHAR(500)	N'$.SearchText'
			,	[ID]			INT				N'$.ID'
		)
	
	SET @RetVal = 
			(
				SELECT 
					COUNT(1)
				FROM [dbo].[User] AS A
			)	

	
	DECLARE @JsonData NVARCHAR(MAX)=(				
		
		SELECT 
			A.[DepartmentId]
			,	A.[Email]
			,	A.[Id]
			,	A.[Name]
			,	A.[Password]
			,	A.[Phone]
			,	A.[RollId]
		FROM [dbo].[User]		AS A
		WHERE A.[Id]	= @ID
		FOR JSON  PATH,WITHOUT_ARRAY_WRAPPER	
	);

	SET	@JsonOutput=@JsonData
	
	SET		@DataType = 2;
END TRY
	BEGIN CATCH
		/* Invalid parameter error */
		SET @ErrorNumber = -1;
		SET	@ErrorMessage	=	ERROR_MESSAGE();
	END  CATCH
END


GO

CREATE PROCEDURE [dbo].[StudentList]
	@Json				NVARCHAR(MAX)
	,	@RetVal			INT OUTPUT
	,	@DataType		INT	OUTPUT
	,	@ErrorNumber	INT	OUTPUT
	,	@ErrorMessage	NVARCHAR(2000)	OUTPUT
	,	@JsonOutput		NVARCHAR(MAX)	=	NULL	OUTPUT 
AS
BEGIN

	SET NOCOUNT ON;

	/* 
		Keep these values global
		Return Values
		 -2		-	Concurrency	Issue
		 -1		-	Record Not Found
		  0		-	No Error (Default Value)
		> 0		-	Record ID
	*/
	DECLARE	@StartPage			INT
	DECLARE		@SearchText		NVARCHAR(500)
	DECLARE		@PageNumber		INT
	DECLARE		@PageSize		INT
	DECLARE		@SortOrder		INT
	DECLARE		@SortDir		INT
	DECLARE		@FilteredCount	INT

	SET @RetVal					=	0;	
	/*
		@DataType
			0	Scalar
			1	Grid
			2	Json
	*/
	SET @DataType				=	0;	
	/*
		-1	Invalid Parameter
	*/
	SET @ErrorNumber			=	0;

	BEGIN TRY

	SELECT
			@PageNumber						=	NULLIF([PageNumber],0)
			,	@PageSize					=	NULLIF([PageSize],0)
			,	@SortOrder					=	[SortOrder]
			,	@SortDir					=	[SortDir]
			,	@SearchText					=	NULLIF([SearchText],'')
		FROM  OPENJSON(@Json)
		WITH
		(
			[PageNumber]		INT				N'$.PageNumber'
			,	[PageSize]		INT				N'$.PageSize'
			,	[SortOrder]		INT				N'$.SortOrder'
			,	[SortDir]		INT				N'$.SortDir'
			,	[SearchText]	NVARCHAR(500)	N'$.SearchText'
		)
	
	SET @RetVal = 
			(
				SELECT 
					COUNT(1)
				FROM [dbo].[User] AS A
			)	

	SET	@PageNumber =ISNULL(@PageNumber,1)
	SET	@PageSize =	COALESCE(@PageSize, ISNULL(NULLIF(@RetVal,0),@PageNumber));

	IF @SearchText IS NOT NULL
		SET @SearchText =  CONCAT('%',@SearchText,'%')

	SET @FilteredCount=
	(

		SELECT 
			COUNT(*)
		FROM [dbo].[User]	AS A
	
	)
	DECLARE @JsonData NVARCHAR(MAX)=(				
		
		SELECT 
			A.[DepartmentId]
			,	A.[Email]
			,	A.[Id]
			,	A.[Name]
			,	A.[Password]
			,	A.[Phone]
			,	A.[RollId]
		FROM [dbo].[User]		AS A
		
		ORDER	BY
		A.[RollId]
			

		OFFSET			@PageSize	* (@PageNumber - 1)	ROWS 
		FETCH	NEXT	@PageSize	ROWS ONLY 
		FOR JSON  PATH	
	);

	SET	@JsonOutput=@JsonData
	
	SET		@DataType = 2;
END TRY
	BEGIN CATCH
		/* Invalid parameter error */
		SET @ErrorNumber = -1;
		SET	@ErrorMessage	=	ERROR_MESSAGE();
	END  CATCH
END

