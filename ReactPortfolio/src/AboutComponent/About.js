import React from "react"
import profilePic from "./Images/edited profile pic.jpg"
import "./About.css"

const about = () => {
    const aboutContainer = (
        <p className="AboutContainer">
            My name is Ashraf Patel I am an individual who has graduated in Business Studies and Computer Programming. In my free time I like to build upon my knowledge of computer programming, perfect my skills and look into various frameworks.
            In the near future I hope to teach others to program effectively and develop apps which benefit others. I have interests in mainly JavaScript programming but can program in Java, PHP, Python and C#. I enjoy programming and love to expand my knowledge base. 
        </p>
    )

    if (profilePic.height < aboutContainer.height) {
        profilePic.display = "hidden";
    }



    return (
        <div className="AboutMe" id = "3rdSect">
            <img src={profilePic} className="profilePic" alt="pic of me" />
            {aboutContainer}
		</div >        
    )
}

export default about