--5.	Commits

SELECT Id, [Message], RepositoryId, ContributorId 
	FROM Commits
  ORDER BY Id

--6.	Front-end

SELECT Id, [Name], Size FROM Files
	WHERE Size > 1000 AND [Name] LIKE N'%html%'
  ORDER BY Size DESC, Id

--7.	Issue Assignment

SELECT i.Id, CONCAT(u.Username, ' : ', i.Title) AS IssueAssignee 
	FROM Issues i
	LEFT JOIN Users u ON i.AssigneeId = u.Id
  ORDER BY i.Id DESC, i.AssigneeId


--8.	Single Files

SELECT Id, [Name], CONCAT(Size, 'KB') AS Size
	FROM Files f
	  WHERE
	   (SELECT TOP(1) ParentId 
	     FROM Files 
		 WHERE ParentId = f.Id) IS NULL
 ORDER BY Id

--9.	Commits in Repositories

SELECT TOP(5) 
		rc.RepositoryId, 
		r.[Name], 
		COUNT(rc.RepositoryId) AS Commits
	FROM Repositories r
	LEFT JOIN Commits c ON r.Id = c.RepositoryId
	LEFT JOIN RepositoriesContributors rc ON r.Id = rc.RepositoryId
  GROUP BY rc.RepositoryId, r.[Name]
  ORDER BY Commits DESC, rc.RepositoryId

--10.	Average Size

SELECT u.Username, AVG(f.Size) AS Size 
		FROM Users u 
	LEFT JOIN Commits c ON u.Id = c.ContributorId
	LEFT JOIN Files f ON c.Id = f.CommitId
	WHERE f.Size IS NOT NULL
	GROUP BY u.Id, u.Username
  ORDER BY Size DESC, u.Username