# NewPlatformService
Following the course https://www.youtube.com/watch?v=DgVjEo3OGBI&amp;t=12s

Publish new image

dotnet publish --os linux --arch x64 -p:PublishProfile=DefaultContainer

Run newly generated image
docker run -p 8080:80 newplatformservice:1.0.0

tag image for publishing
docker tag newplatformservice:1.0.0 wontlearn2codewithme/newplatformservice

push image to dockerhub 
docker push wontlearn2codewithme/newplatformservice:1.0.0
