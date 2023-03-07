# Architectural Decisions



1. What folder structure and naming convention will you use for your project source code? You'll have at least 4 projects: 1) the main project, 2) NUnit testing project, 3) BDD testing project, and 4) Jest javascript testing project. Your test projects should all begin or end in the word Tests_ or _Tests.

        File names should have every word capitalized. 
        We will name test files using _Tests

2. What .NET Core version to use?

        MVC .NET Core 7.0.2


3. What front-end CSS library and version are you going to use? I recommend the latest version of Bootstrap, but we have had teams use other libraries. Two years ago a team went with a really nice minimalist design and used UIkit. I've used Materialize for it's smaller and simpler approach. Tailwind CSS seems to be really popular right now. You may also want to talk about whether or not theme-ing is important for your project.

        We are going to use standard CSS and Bootstrap

4. Decide on how you'll use Javascript: jQuery (which version) or go for plain old JS. Any other libraries you think you'll want to use? Regardless of your decision, all team members must follow the same convention -- no mix and match.

        We will use JavaScript


5. How will you name your Git branches? Choose a strategy. Unfortunately it looks like the “Create Branch” feature in Jira is only available for Bitbucket repositories or GitHub repos with an Enterprise Account. It won't create a branch for you with a personal account but it will recommend names.

        The template we will follow for naming Git branches is MA-US-[number]-[story name]


6. How will you write your database scripts, table names, PK and FK names? Because of some tools I'll give you later, I'm making this decision for you. See the example I'll put in the module. It'll be required that everyone follow this example to the letter!


        See Our_DB_syntax.svg and other files on Canvas
    

7. Will you use eager loading or enable lazy loading of related entities in Entity Framework Core? 

        We will use lazy loading
