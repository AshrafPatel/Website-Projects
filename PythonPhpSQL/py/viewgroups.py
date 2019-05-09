#!C:\Program Files\Python37\python.exe
import pickle
import mysql.connector
import cgi

print("Content-Type: text/html \n\n")
print("<style>")
print("body{ background-color: #ceb6f9; }")
print(".container { border-radius: 5px; background-color: #DCD6F7; padding: 20px;")
print("text-align: center; width: 80%; margin: auto; margin-bottom: 10px; }")
print("table{border-collapse: collapse; font-family: 'Trebuchet MS', Arial, Helvetica, sans-serif; width: 100%;")
print("border: 5px solid rgb(128, 135, 172); color: #a6b1e1; margin: auto; margin-bottom: 30px;}")
print("th{ background-color: #8c94c4; height: 70px; font-size: 20px; color: black; transition: 0.7s; padding: 15px; }")
print("td{ padding: 10px; border: 5px solid #8087AC; }")
print("tr:nth-child(even){ background-color: #969ccd; color: black; }")
print("tr:nth-child(odd){ background-color: #9095c1; color: black; }")
print("th:hover{ opacity: 1; background-color: #b2c0f0; }")
print("tr:not(:first-child):hover{ background-size:  25% 25%; transform:scale(1.123,1.34); transform-origin:center; }")
print("h1{ font-family: 'Trebuchet MS', Arial, Helvetica, sans-serif; text-align: center; }")
print("h2{ font-family: 'Trebuchet MS', Arial, Helvetica, sans-serif; text-align: center; }")
print("</style>")


class Student(object):
    def __init__(self, fName, lName, eMail, pNumber, pWord, regID, groupID):
        self.fName = fName
        self.lName = lName
        self.eMail = eMail
        self.pNumber = pNumber
        self.pWord = pWord
        self.regID = regID
        self.groupID = groupID

    def __repr__(self):
        return repr((self.fName, self.lName, self.eMail, self.pNumber, self.pWord, self.regID, self.groupID))

    def __getitem__(self, item):
        if item == 0:
            return self.fName
        elif item == 1:
            return self.lName
        elif item == 2:
            return self.eMail
        elif item == 3:
            return self.pNumber
        elif item == 4:
            return self.pWord
        elif item == 5:
            return self.regID
        elif item == 6:
            return self.groupID


form = cgi.FieldStorage()
userName = form.getvalue('getUname')

with open('../txt/groupfile.txt', 'rb') as handle:
    allStudents = pickle.load(handle)

groupNumber = 0


def findstudentgroup(username):
    for aStudent in allStudents:
        if userName == aStudent[2] or userName == aStudent[5]:
            groupNumber = aStudent[6]
    return groupNumber

print("<div class='container'>")
print("<h1>Your Group</h1>")
print("<table border=1>")
print("<tr>")
print("<th>First Name</th>")
print("<th>Last Name</th>")
print("<th>Email</th>")
print("<th>Phone Number</th>")
print("</tr>")

for oneStudent in allStudents:
    if findstudentgroup(userName) == oneStudent[6]:
        print("<tr>")
        print("<td>" + oneStudent[0] + "</td>")
        print("<td>" + oneStudent[1] + "</td>")
        print("<td>" + oneStudent[2] + "</td>")
        print("<td>" + oneStudent[3] + "</td>")
        print("</tr>")
print("</table>")
print("<div class='container'>")
