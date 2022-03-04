-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema srednja_skola_hci
-- -----------------------------------------------------
DROP SCHEMA IF EXISTS `srednja_skola_hci` ;

-- -----------------------------------------------------
-- Schema srednja_skola_hci
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `srednja_skola_hci` DEFAULT CHARACTER SET utf8 COLLATE utf8_unicode_ci ;
USE `srednja_skola_hci` ;

-- -----------------------------------------------------
-- Table `srednja_skola_hci`.`OSOBA`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `srednja_skola_hci`.`OSOBA` ;

CREATE TABLE IF NOT EXISTS `srednja_skola_hci`.`OSOBA` (
  `JMB` CHAR(13) NOT NULL,
  `Ime` VARCHAR(20) NOT NULL,
  `Prezime` VARCHAR(20) NOT NULL,
  `DatumRodjenja` DATE NOT NULL,
  `Pol` ENUM('muski', 'zenski') NOT NULL,
  `Adresa` VARCHAR(255) NOT NULL,
  `mail_adresa` VARCHAR(255) NOT NULL,
  `lozinka` VARCHAR(255) NOT NULL,
  `jezik` ENUM('EN', 'SR') NOT NULL,
  `tema` ENUM('B', 'C', 'P') NOT NULL,
  PRIMARY KEY (`JMB`),
  UNIQUE INDEX `mail_adresa_UNIQUE` (`mail_adresa` ASC) VISIBLE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `srednja_skola_hci`.`PROFESOR`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `srednja_skola_hci`.`PROFESOR` ;

CREATE TABLE IF NOT EXISTS `srednja_skola_hci`.`PROFESOR` (
  `Verifikovan` TINYINT(1) NOT NULL,
  `Plata` DECIMAL UNSIGNED NOT NULL,
  `JMB` CHAR(13) NOT NULL,
  PRIMARY KEY (`JMB`),
  INDEX `fk_PROFESOR_OSOBA1_idx` (`JMB` ASC) VISIBLE,
  CONSTRAINT `fk_PROFESOR_OSOBA1`
    FOREIGN KEY (`JMB`)
    REFERENCES `srednja_skola_hci`.`OSOBA` (`JMB`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `srednja_skola_hci`.`SKOLA`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `srednja_skola_hci`.`SKOLA` ;

CREATE TABLE IF NOT EXISTS `srednja_skola_hci`.`SKOLA` (
  `Naziv` VARCHAR(255) NOT NULL,
  `mail_adresa` VARCHAR(45) NOT NULL,
  `Vrsta` VARCHAR(45) NOT NULL,
  `JIB` CHAR(13) NOT NULL,
  `Adresa` VARCHAR(255) NOT NULL,
  `Telefon` VARCHAR(45) NULL,
  UNIQUE INDEX `e-mail adresa_UNIQUE` (`mail_adresa` ASC) VISIBLE,
  PRIMARY KEY (`JIB`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `srednja_skola_hci`.`SMJER`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `srednja_skola_hci`.`SMJER` ;

CREATE TABLE IF NOT EXISTS `srednja_skola_hci`.`SMJER` (
  `IdSmjera` INT NOT NULL,
  `Trajanje_Godina` INT NOT NULL,
  `Naziv` VARCHAR(45) NULL,
  `SKOLA_JIB` CHAR(13) NOT NULL,
  `Zvanje` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`IdSmjera`),
  INDEX `fk_SMJER_SKOLA1_idx` (`SKOLA_JIB` ASC) VISIBLE,
  CONSTRAINT `fk_SMJER_SKOLA1`
    FOREIGN KEY (`SKOLA_JIB`)
    REFERENCES `srednja_skola_hci`.`SKOLA` (`JIB`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `srednja_skola_hci`.`UCENIK`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `srednja_skola_hci`.`UCENIK` ;

CREATE TABLE IF NOT EXISTS `srednja_skola_hci`.`UCENIK` (
  `Odjeljenje` TINYINT UNSIGNED NOT NULL,
  `Razred` TINYINT UNSIGNED NOT NULL,
  `BrojMaticneKnjige` CHAR(7) NOT NULL,
  `Obnova` TINYINT(1) NOT NULL,
  `IdSmjera` INT NOT NULL,
  `JMB_RAZREDNIKA` CHAR(13) NOT NULL,
  `JMB` CHAR(13) NOT NULL,
  PRIMARY KEY (`JMB`),
  UNIQUE INDEX `BrojMaticneKnjige_UNIQUE` (`BrojMaticneKnjige` ASC) VISIBLE,
  INDEX `fk_UCENIK_SMJER1_idx` (`IdSmjera` ASC) VISIBLE,
  INDEX `fk_UCENIK_OSOBA1_idx` (`JMB` ASC) VISIBLE,
  UNIQUE INDEX `JMB_UNIQUE` (`JMB` ASC) VISIBLE,
  CONSTRAINT `fk_UCENIK_SMJER1`
    FOREIGN KEY (`IdSmjera`)
    REFERENCES `srednja_skola_hci`.`SMJER` (`IdSmjera`)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_UCENIK_OSOBA1`
    FOREIGN KEY (`JMB`)
    REFERENCES `srednja_skola_hci`.`OSOBA` (`JMB`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `srednja_skola_hci`.`PREDMET`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `srednja_skola_hci`.`PREDMET` ;

CREATE TABLE IF NOT EXISTS `srednja_skola_hci`.`PREDMET` (
  `IdPredmeta` INT NOT NULL AUTO_INCREMENT,
  `Naziv` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`IdPredmeta`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `srednja_skola_hci`.`PREDMET_NA_SMJERU`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `srednja_skola_hci`.`PREDMET_NA_SMJERU` ;

CREATE TABLE IF NOT EXISTS `srednja_skola_hci`.`PREDMET_NA_SMJERU` (
  `IdPredmeta` INT NOT NULL,
  `IdSmjera` INT NOT NULL,
  `Tip` CHAR(1) NOT NULL,
  `Razred` TINYINT(1) NULL,
  `MinimalniBrojPismenihProvjera` TINYINT UNSIGNED NOT NULL,
  `MinimalniBrojUsmenihProvjera` TINYINT UNSIGNED NOT NULL,
  PRIMARY KEY (`IdPredmeta`, `IdSmjera`),
  INDEX `fk_PREDMET_has_SMJER_SMJER1_idx` (`IdSmjera` ASC) VISIBLE,
  INDEX `fk_PREDMET_has_SMJER_PREDMET1_idx` (`IdPredmeta` ASC) VISIBLE,
  CONSTRAINT `fk_PREDMET_has_SMJER_PREDMET1`
    FOREIGN KEY (`IdPredmeta`)
    REFERENCES `srednja_skola_hci`.`PREDMET` (`IdPredmeta`)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_PREDMET_has_SMJER_SMJER1`
    FOREIGN KEY (`IdSmjera`)
    REFERENCES `srednja_skola_hci`.`SMJER` (`IdSmjera`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `srednja_skola_hci`.`PROVJERA`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `srednja_skola_hci`.`PROVJERA` ;

CREATE TABLE IF NOT EXISTS `srednja_skola_hci`.`PROVJERA` (
  `Datum` DATE NOT NULL,
  `Tip` ENUM('P', 'U') NOT NULL,
  `TrajanjeMin` INT NOT NULL,
  `BrojNegativnihOcjena` INT NOT NULL,
  `BrojPrisutnihUcenika` INT NOT NULL,
  `Ponovljena` TINYINT(1) NULL,
  `IdPredmeta` INT NOT NULL,
  `IdSmjera` INT NOT NULL,
  `Odjeljenje` TINYINT NOT NULL,
  PRIMARY KEY (`Datum`, `IdPredmeta`, `IdSmjera`, `Odjeljenje`),
  INDEX `fk_PROVJERA_PREDMET_NA_SMJERU1_idx` (`IdPredmeta` ASC, `IdSmjera` ASC) VISIBLE,
  CONSTRAINT `fk_PROVJERA_PREDMET_NA_SMJERU1`
    FOREIGN KEY (`IdPredmeta` , `IdSmjera`)
    REFERENCES `srednja_skola_hci`.`PREDMET_NA_SMJERU` (`IdPredmeta` , `IdSmjera`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `srednja_skola_hci`.`RADI_PROVJERU`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `srednja_skola_hci`.`RADI_PROVJERU` ;

CREATE TABLE IF NOT EXISTS `srednja_skola_hci`.`RADI_PROVJERU` (
  `Datum` DATE NOT NULL,
  `IdPredmeta` INT NOT NULL,
  `IdSmjera` INT NOT NULL,
  `Odjeljenje` TINYINT NOT NULL,
  `Ocjena` TINYINT NULL,
  `UCENIK_JMB` CHAR(13) NOT NULL,
  PRIMARY KEY (`Datum`, `IdPredmeta`, `IdSmjera`, `Odjeljenje`, `UCENIK_JMB`),
  INDEX `fk_UCENIK_has_PROVJERA_PROVJERA1_idx` (`Datum` ASC, `IdPredmeta` ASC, `IdSmjera` ASC, `Odjeljenje` ASC) VISIBLE,
  INDEX `fk_RADI_PROVJERU_UCENIK1_idx` (`UCENIK_JMB` ASC) VISIBLE,
  CONSTRAINT `fk_UCENIK_has_PROVJERA_PROVJERA1`
    FOREIGN KEY (`Datum` , `IdPredmeta` , `IdSmjera` , `Odjeljenje`)
    REFERENCES `srednja_skola_hci`.`PROVJERA` (`Datum` , `IdPredmeta` , `IdSmjera` , `Odjeljenje`)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_RADI_PROVJERU_UCENIK1`
    FOREIGN KEY (`UCENIK_JMB`)
    REFERENCES `srednja_skola_hci`.`UCENIK` (`JMB`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `srednja_skola_hci`.`PREDAJE`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `srednja_skola_hci`.`PREDAJE` ;

CREATE TABLE IF NOT EXISTS `srednja_skola_hci`.`PREDAJE` (
  `IdPredmeta` INT NOT NULL,
  `IdSmjera` INT NOT NULL,
  `PROFESOR_JMB` CHAR(13) NOT NULL,
  `BrojSedmicnihCasova` TINYINT UNSIGNED NOT NULL,
  PRIMARY KEY (`IdPredmeta`, `IdSmjera`, `PROFESOR_JMB`),
  INDEX `fk_PROFESOR_has_PREDMET_NA_SMJERU_PREDMET_NA_SMJERU1_idx` (`IdPredmeta` ASC, `IdSmjera` ASC) VISIBLE,
  INDEX `fk_PREDAJE_PROFESOR1_idx` (`PROFESOR_JMB` ASC) VISIBLE,
  CONSTRAINT `fk_PROFESOR_has_PREDMET_NA_SMJERU_PREDMET_NA_SMJERU1`
    FOREIGN KEY (`IdPredmeta` , `IdSmjera`)
    REFERENCES `srednja_skola_hci`.`PREDMET_NA_SMJERU` (`IdPredmeta` , `IdSmjera`)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_PREDAJE_PROFESOR1`
    FOREIGN KEY (`PROFESOR_JMB`)
    REFERENCES `srednja_skola_hci`.`PROFESOR` (`JMB`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `srednja_skola_hci`.`IMA_NASTAVU`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `srednja_skola_hci`.`IMA_NASTAVU` ;

CREATE TABLE IF NOT EXISTS `srednja_skola_hci`.`IMA_NASTAVU` (
  `UCENIK_JMB` CHAR(13) NOT NULL,
  `IdPredmeta` INT NOT NULL,
  `IdSmjera` INT NOT NULL,
  PRIMARY KEY (`UCENIK_JMB`, `IdPredmeta`, `IdSmjera`),
  INDEX `fk_UCENIK_has_PREDMET_NA_SMJERU_PREDMET_NA_SMJERU1_idx` (`IdPredmeta` ASC, `IdSmjera` ASC) VISIBLE,
  INDEX `fk_UCENIK_has_PREDMET_NA_SMJERU_UCENIK1_idx` (`UCENIK_JMB` ASC) VISIBLE,
  CONSTRAINT `fk_UCENIK_has_PREDMET_NA_SMJERU_UCENIK1`
    FOREIGN KEY (`UCENIK_JMB`)
    REFERENCES `srednja_skola_hci`.`UCENIK` (`JMB`)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_UCENIK_has_PREDMET_NA_SMJERU_PREDMET_NA_SMJERU1`
    FOREIGN KEY (`IdPredmeta` , `IdSmjera`)
    REFERENCES `srednja_skola_hci`.`PREDMET_NA_SMJERU` (`IdPredmeta` , `IdSmjera`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `srednja_skola_hci`.`ADMIN`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `srednja_skola_hci`.`ADMIN` ;

CREATE TABLE IF NOT EXISTS `srednja_skola_hci`.`ADMIN` (
  `JMB` CHAR(13) NOT NULL,
  PRIMARY KEY (`JMB`),
  CONSTRAINT `fk_ADMIN_OSOBA1`
    FOREIGN KEY (`JMB`)
    REFERENCES `srednja_skola_hci`.`OSOBA` (`JMB`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
