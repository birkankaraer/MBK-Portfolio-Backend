# 🌐 Kişisel Web Sitem / Personal Website

## 📋 Açıklama / Description

Angular ile geliştirdiğim kişisel web sitemin arka uç tarafı. ASP.NET Core çerçevesinde geliştirdiğim bir API web uygulaması. RESTful API tasarım deseni ile geliştirilen API uygulaması.

The backend of my personal website developed with Angular. It is an API web application developed within the ASP.NET Core framework. The API application is developed with the RESTful API design pattern.

## 🚀 Dağıtım / Deployment

API projemi ilk başta Azure bulut sistemini kullanarak deploy ettim ve aynı şekilde MSSQL database tarafını da deploy ettim, yani iki koldan deploy ettim. Ücretsiz kullanma hakkım bittikten sonra MonsterASP.net sitesinin ücretsiz hosting hizmetini kullandım ve yine aynı şekilde API uygulamamı ve veri tabanımı deploy ettim.

Initially, I deployed my API project using the Azure cloud system and similarly deployed the MSSQL database, deploying both components. After my free usage period ended, I used the free hosting service of MonsterASP.net and similarly deployed my API application and database.

## ⚠️ Sorunlar (Çözüldü) / Issues (Solved)

Bu kullandığım ücretsiz hosting servisi HTTP protokolü üzerinden canlıya aldı projemi ancak web arayüzüm HTTPS üzerinde yayında olduğu için mixed content hatası alıyorum. Bu yüzden backend servisim düzgün çalışmıyor.

This free hosting service published my project using the HTTP protocol, but since my web interface is live on HTTPS, I get a mixed content error. Therefore, my backend service does not work properly.

Mixed content hatası yaşamadan önce HTTP protokolünde olan backend API servisimi HTTPS protokolüne taşıdım ve bu sorunu çözdüm.

Before encountering mixed content issues, I migrated the backend API service from HTTP to HTTPS protocol, resolving this issue.

## 🛠️ Teknolojiler / Technologies

- Frontend: Angular
- Backend: ASP.NET Core Web API
- Database: MSSQL
- Deployment: Azure, MonsterASP.net

---

👨‍💻 **Geliştirici / Developer:** Mustafa Birkan Karaer

📧 **İletişim / Contact:** karaermustafabirkan@gmail.com
