SELECT
	T0."AcademicRecord"
	, T0."Name"
	, T0."Period"
	, T0."Picture"
	, T0."CourseId"
	, T1."Name" as "Course Name"
	, T3."SubjectId"
	, T3."Name" as "Subject Name"
	, T3."PassingScore" as "Passing Score"
	, T4."Value" as "Current Score"
	, CONCAT(
		(CASE WHEN T4."Value" IS NOT NULL 
		THEN 
			CASE WHEN T4."Value" >= T3."PassingScore"
				THEN 'Aprovado em ' 
				ELSE 'Reprovado em '
				END
		ELSE
			'Não possui nota em ' END), T3."Name") AS "Status"
FROM 
	"Student" T0
INNER JOIN 
	"Course" T1 ON T0."CourseId" = T1."CourseId"
INNER JOIN
	"CourseSubject" T2 ON T1."CourseId" = T2."CourseId"
INNER JOIN
	"Subject" T3 ON T2."SubjectId" = T3."SubjectId"
LEFT JOIN
	"Grade" T4 ON T0."AcademicRecord" = T4.AcademicRecord
					AND T3."SubjectId" = T4."SubjectId"

WHERE
		LOWER(T0."AcademicRecord") = '{academicRecord.ToLower()}'
	OR	LOWER(T0."Name") = '{name}'
	OR	T1."CourseId" = {courseId}
	OR	LOWER(CONCAT(
			(CASE WHEN T4."Value" IS NOT NULL 
			THEN 
				CASE WHEN T4."Value" >= T3."PassingScore"
					THEN 'Aprovado em ' 
					ELSE 'Reprovado em '
					END
			ELSE
				'Não possui nota em ' END), T3."Name")) = '{status}'