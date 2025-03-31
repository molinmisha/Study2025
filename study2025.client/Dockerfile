# Базовый образ с Node.js
FROM node:20-alpine
WORKDIR /app
COPY package*.json ./
RUN npm install
COPY . .
RUN npm run build --prod
CMD ["npx", "http-server", "dist/study2025.client", "-p", "80"]



## Этап сборки
#FROM node:18 AS build
#WORKDIR /app
#
## Копируем package.json и устанавливаем зависимости
#COPY study2025.client/package*.json ./
#RUN npm install
#
## Копируем исходный код и собираем проект
#COPY study2025.client/. .
#RUN npm run build --configuration=production
#
## Финальный образ с nginx
#FROM nginx:alpine
#COPY --from=build /app/dist/study2025.client /usr/share/nginx/html
#COPY nginx.conf /etc/nginx/nginx.conf
#EXPOSE 80
#
