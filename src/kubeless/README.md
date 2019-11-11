## Installation Rancher

* Exécutez cette commande sur la VM (ou via SSH):
    * `sudo docker run -d --restart=unless-stopped -p 880:80 -p 8443:443 rancher/rancher`

## Installation Kubernetes

* Créer un cluster dans Rancher
    * Sur l’écran principal, cliquez sur **"Add Cluster"**
    * Choisissez **"Custom"**
    * Donnez un nom au cluster et cliquez sur **"Next"**
    * Sélectionnez les trois roles (controlplane, etcd, worker)
    * Copiez la commande

* Exécuter sur le nœud la commande fournie dans le terminal VS-Code

## Configuration client Kubectl

* Dans rancher, aller sur le cluster
* Cliquez sur **"Kubeconfig File"** puis sur **"Copy to Clipboard"**
* Dans le ternimal de VS-Code online
* Executer la commande: `mkdir ~/.kube/`
* Ouvrir le dossier `/home/coder/.kube/`
* Créer un fichier `config` et y coller le contenu copié précédement
* Vérifier la configuration à l’aide de la commande: `kubectl cluster-info`

## Installation Kubeless

* Récupération de la version
    * `export RELEASE=$(curl -s https://api.github.com/repos/kubeless/kubeless/releases/latest | grep tag_name | cut -d '"' -f 4)`
* Création d’un namespace
    * `kubectl create ns kubeless`
* Installation de Kubeless
    * `kubectl create -f https://github.com/kubeless/kubeless/releases/download/$RELEASE/kubeless-$RELEASE.yaml`
* Vérification de l’installation
    * `kubectl get deployment -n kubeless`

## Installation Kubeless UI
* Installation de Kubeless UI
    * `kubectl create -f https://raw.githubusercontent.com/kubeless/kubeless-ui/master/k8s.yaml`
* Créer un projet **"kubeless"** et déplacer le namespace **"kubeless"** dedans
    * Sur le cluster, cliquez sur **"Namespaces/Projects"**
    * Cliquez sur **"Add Project"**, entrez un nom et sauvez
    * Cochez le namespace **"kubeless"** et cliquez sur **"Move"** pour le déplacer dans le projet créé

## Rendre Kubeless UI disponible
* Allez dans le projet
* Allez dans l’onglet **"Load Balancing"**
* Cliquez sur **"Add Ingress"**
* Entrez un nom
* Choisissez **"Specify a hostname to use"** et entre le nom 
    * `kubeless.<ip-de-la-vm>.xip.io`
* Ajoutez un service pour **"ui"**

