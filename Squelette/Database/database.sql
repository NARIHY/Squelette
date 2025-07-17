CREATE TABLE lovox_users (
    id INT AUTO_INCREMENT PRIMARY KEY,
    matricule VARCHAR(50) NOT NULL UNIQUE,
    nom VARCHAR(100) NOT NULL,
    password VARCHAR(255) NOT NULL,
    role ENUM('client', 'admin') NOT NULL DEFAULT 'client',
    created_at DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    updated_at DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;


CREATE TABLE user_logs (
    id INT AUTO_INCREMENT PRIMARY KEY,
    user_id INT NOT NULL,
    machine_name VARCHAR(255) NOT NULL,
    login_time DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    logout_time DATETIME DEFAULT NULL,
    FOREIGN KEY (user_id) REFERENCES lovox_users(id)
        ON DELETE CASCADE
        ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;


# Test

INSERT INTO lovox_users (matricule, nom, password, role)
VALUES 
('CL001', 'Client Demo', '1234', 'client'),
('AD001', 'Admin Demo', '1234', 'admin');


CREATE TABLE login_infos (
    id INT AUTO_INCREMENT PRIMARY KEY,
    matricule VARCHAR(50) NOT NULL UNIQUE,
    login_c3x VARCHAR(100),
    password_c3x VARCHAR(100),
    login_voxco VARCHAR(100),
    password_voxco VARCHAR(100),
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (matricule) REFERENCES lovox_users(matricule) ON DELETE CASCADE
);

INSERT INTO login_infos (
    matricule, login_c3x, password_c3x, login_voxco, password_voxco
) VALUES 
('CL001', 'client_c3x', 'pwd123C3X', 'client_voxco', 'pwd123VOXCO'),
('AD001', 'admin_c3x', 'adminPwdC3X', 'admin_voxco', 'adminPwdVOXCO');

# Intégration de l'ip
ALTER TABLE user_logs ADD COLUMN ip VARCHAR(45) AFTER password_voxco;