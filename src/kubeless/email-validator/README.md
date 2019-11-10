Aller dans le dossier: `cd src/kubeless/email-validator`

## Premier déploiement
`kubeless function deploy email --runtime nodejs12 --from-file function.js --handler email.validate`

## Mise à jour
`kubeless function update email --runtime nodejs12 --from-file function.js --handler email.validate`
