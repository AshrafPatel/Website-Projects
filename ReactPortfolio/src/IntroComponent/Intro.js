import React from "react"
import "./Intro.css"

const intro = () => {
    return (
            <div className="Intro" id="1stSect">
                <img src="https://farm1.staticflickr.com/801/26363689807_9af6426cb1_b.jpg" className="AP" alt="The person who created this awesome page" />
                <div className="weblinkcontainer">
                    <a href="https://www.freecodecamp.org/ashrafpatel">
                        <button id="fcc">
                            <i className="fab fa-free-code-camp"></i>FreeCodeCamp
				</button>
                    </a>
                    <a href="https://www.linkedin.com/in/ashr4fpatel/">
                        <button id="linkedin">
                            <i className="fab fa-linkedin"></i>LinkedIn
				</button>
                    </a>
                    <a href="https://github.com/AshrafPatel">
                        <button id="github">
                            <i className="fab fa-github"></i>GitHub
				</button>
                    </a>
                <a href="https://codepen.io/4shr4f/">
                        <button id="wordpress">
                            <i className="fab fa-codepen"></i>CodePen
				</button>
                    </a>
                </div>     
        </div>
    )
}

export default intro