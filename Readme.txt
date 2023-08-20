Before creating container images and running containers referenced here, you need an installation of Docker
We recommend installing Docker Desktop when using Windows or MacOS, and Docker Engine when using Linux 
See https://docs.docker.com/engine/install/ for available downloads and further help on how to use Docker

--------------------------------------------------------------------------------------------------------------------------------

Running dockerApi with Docker:
    
    Begin by navigating to the directory containing the Dockerfile, in this case "dockerApi"
    
    Then, create an image to be instantiated into containers using the command 
        docker build -t <yourImageName> .    
    
    Having created an image from the commands within the Dockerfile in the current directory, 
    we may now instantiate it into an actual container using either
        docker run -p 8080:80 <yourImageName>
    or if you want the container running in the background as a detached process
        docker run -d -p 8080:80 <yourImageName>

    When you instantiate an image into either a detached or non-detached container, 
    that instance is automatically given an ID and a NAME by docker 
    To view the containers on your machine and their respective IDs and NAMEs, use the command 
        docker ps 

    A created container may be removed, stopped, and restarted again, using either it's ID or NAME in the commands below
    Remove a single container with 
        docker rm <ID or NAME>
    Remove all stopped containers with
        docker container prune
    Stop a container with
        docker stop <ID or NAME>
    Start a container with 
        docker start <ID or NAME>

--------------------------------------------------------------------------------------------------------------------------

Running dockerApp with Docker:
    
    Begin by navigating to the directory containing the Dockerfile, in this case "dockerApp"
    
    Then, create an image to be instantiated into containers using the command 
        docker build -t <yourImageName> .    
    
    Having created an image from the commands within the Dockerfile in the current directory, 
    we may now instantiate it into an actual container using either
        docker run -p 5000:80 <yourImageName>
    or if you want the container running in the background as a detached process
        docker run -d -p 5000:80 <yourImageName>

    When you instantiate an image into either a detached or non-detached container, 
    that instance is automatically given an ID and a NAME by docker 
    To view the containers on your machine and their respective IDs and NAMEs, use the command 
        docker ps 

    A created container may be removed, stopped, and restarted again, using either it's ID or NAME in the commands below
    Remove a single container with 
        docker rm <ID or NAME>
    Remove all stopped containers with
        docker container prune
    Stop a container with
        docker stop <ID or NAME>
    Start a container with 
        docker start <ID or NAME>

-------------------------------------------------------------------------------------------------------------------------------

Running dockerApi and dockerApp composed together using Docker Compose:

    Docker Compose makes it very easy to test the two applications together
    
    The docker-compose.yml defines a network for them to communicate with each other 
    while also mapping the container ports of each to host ports, allowing us to communicate with both apps through localhost:<port>
    
    This docker-compose.yml also sets the environments of both containers to Development, 
    allowing the applications within them to access URLs made for local development, and also outputting more detailed error messages

    Begin by navigating to the directory of the docker-compose.yml, in this case "dooker"

    Run the composition of this docker-compose.yml using 
        docker compose up --build
    or detached using   
        docker compose up -d --build
    
    Stop the non-detached composition of this docker-compose.yml using
        Ctrl+C

    Stop the detached composition of this docker-compose.yml using   
        docker compose down 

    With both containers running so composed, 
    dockerApi should be accessible on localhost:8080 while 
    dockerApp should be accessible on localhost:5000

    Note that the containers use the service names and container ports of each other 
    when communicating with each other over the network defined in this docker-compose.yml, with 
    dockerApp containers using 
        dockerapi:80 
    instead of 
        localhost:8080 
    to access dockerApi endpoints   