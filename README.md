# krusty-krab
Backend service for the Krusty Krab

## Local setup
Configuration lives in a `.env` file at the repo root, which is gitignored. Create yours from
the template and fill in the password:

```
cp .env.example .env
```

## Local database
MySQL runs in Docker and reads its root password and database name from `.env`:

```
docker run -d --name krusty-krab-mysql \
  --env-file .env \
  -p 3306:3306 \
  -v krusty-krab-mysql-data:/var/lib/mysql \
  mysql:26.7
```

The named volume keeps data across container restarts and removals. Day to day:

```
docker start krusty-krab-mysql     # start it again after a reboot
docker stop krusty-krab-mysql
docker exec -it krusty-krab-mysql sh -c 'mysql -uroot -p"$MYSQL_ROOT_PASSWORD" "$MYSQL_DATABASE"'   # SQL shell
docker rm -f krusty-krab-mysql && docker volume rm krusty-krab-mysql-data   # wipe everything
```

Then run the migrations (below) to create the tables and seed data.

## Database migrations
Schema changes live as plain SQL in `db/migrations/`, applied in filename order by DbUp
(`src/KrustyKrab.Migrations`). Applied scripts are tracked in the `schemaversions` table, so
never edit a script that has already run; add a new numbered one instead.

The connection string is read from `ConnectionStrings__DefaultConnection` in `.env`. A real
environment variable of the same name takes precedence, for CI and cloud deployments.

```
dotnet run --project src/KrustyKrab.Migrations -- --dry-run   # list pending scripts
dotnet run --project src/KrustyKrab.Migrations                # apply them (creates the database if missing)
```

# job description we're making this for
What you’ll be responsible for:

    Design, develop, and maintain scalable backend services and APIs using C#/.NET. 
    Build and support event-driven applications utilizing AWS services such as EventBridge, Lambda, SQS, SNS, Step Functions, ECS, and related cloud-native technologies. 
    Design and implement high-volume batch processing systems capable of handling large-scale payment workloads efficiently and reliably. 
    Develop secure and resilient payment processing solutions that integrate with banking networks, payment gateways, and third-party service providers. 
    Participate in architecture discussions and contribute to strategic modernization initiatives. 
    Define and promote engineering standards, best practices, and design patterns for backend development. 
    Collaborate closely with Product Owners, QA, Operations, and other engineering teams throughout the software development lifecycle. 
    Perform code reviews and mentor engineers on backend development, cloud architecture, and software engineering best practices. 
    Leverage AI tools and modern engineering practices to improve development productivity, software quality, and operational efficiency. 
    Create and maintain technical documentation, test plans, and operational support guides. 
    Participate in Agile ceremonies including sprint planning, daily stand-ups, backlog refinement, and retrospectives. 
    Provide production support, troubleshooting, root cause analysis, and participate in on-call rotations for critical business systems. 
    May perform other job duties as assigned.

What you’ll need to have:

    Bachelor's degree in Computer Science, Software Engineering, Information Systems, or related technical field.
    4 years of software development experience, including: 

    2+ years developing enterprise applications using C# and .NET. 
    2+ years designing and supporting RESTful APIs and backend services. 
    Experience building large-scale batch processing applications.

    Strong experience designing and implementing event-driven architectures and asynchronous processing patterns. 

    Hands-on experience with AWS cloud services, including EventBridge, Lambda, SQS, SNS, ECS, CloudWatch, and related technologies. 

    Proven experience integrating with payment processors, banking systems, ACH networks, or payment gateways. 

    Experience working with MySQL and SQL Server, including: 

    Database schema design. 

    Query optimization. 

    Stored procedures and functions. 

    Performance tuning.
