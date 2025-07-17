# Récupération de tous les éléments
SELECT * FROM table_name;

# Récupération avec filtre
SELECT * FROM table_name WHERE CONDITION AND CONDITION;

# Compter 
SELECT COUNT(*) AS attribut FROM table_name;

# Compter avec filtre
SELECT COUNT(*) AS attribut FROM table_name WHERE CONDITION;
SELECT COUNT(*) AS attribut FROM table_name WHERE CONDITION AND CONDITION;

# Mettre à jour une seul selection
UPDATE table_name SET CONDITION WHERE CONDITION;

# exemple
UPDATE USER SET username="John" WHERE id = 1;

# Mettre à jours plusieurs lignes
UPDATE table_name SET CONDITION WHERE CONDITION;

#TRIE PAGINATION
SELECT * FROM table_name ORDER BY COLUMN DESC/ASC;

# Trie de pagination avec filtre
SELECT * FROM table_name ORDER BY COLUMN DESC/ASC LIMITE number OFFSET number;

# Utilisation de like pour recherche
SELECT * FROM table_name WHERE COLUMN LIKE MODELE;
