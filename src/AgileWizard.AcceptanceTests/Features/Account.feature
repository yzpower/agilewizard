﻿Feature: Account
	In order to indentify user
	As a website master
	I want user to login with username and password

@Ignor
Scenario: Login
	Given open login page
	And enter username - 'agilewizard' and password - 'agilewizard'
	When press login button
	Then should be redirected to main page
