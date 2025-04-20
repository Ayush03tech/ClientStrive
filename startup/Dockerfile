# Use Node.js 22 (ARM64 support for Apple Silicon)
FROM --platform=linux/arm64 node:22 AS build-stage

# Set working directory inside the container
WORKDIR /app

# Copy package.json and package-lock.json
COPY package*.json ./

# Install dependencies
RUN npm install

# Copy the entire Angular project into the container
COPY . .

# Build the Angular app
# RUN npm run build --prod

#Build the Angular app with docker config 
RUN npm run build -- --configuration=docker

# Use Nginx as the web server (optimized for serving static files)
FROM --platform=linux/arm64 nginx:alpine AS production-stage

# Set the working directory inside Nginx
WORKDIR /usr/share/nginx/html

# Remove the default Nginx static files
RUN rm -rf ./*

# Copy the built Angular files from the previous stage  
COPY --from=build-stage /app/dist/startup/browser /usr/share/nginx/html

# Expose port 80
EXPOSE 80

# Start Nginx
CMD ["nginx", "-g", "daemon off;"]
