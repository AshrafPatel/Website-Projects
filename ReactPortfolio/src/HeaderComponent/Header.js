import React from "react"
import "./Header.css"


const header = () => {

    const aStyle = {
        display: "inline-block",
        background: "white",
        textAlign: "center",
        textDecoration: "none",
        fontSize: "25px",
        color: "black",
        flex: "1",
        width: "300px"
    }

    const navStyle = {
        overflow: "hidden",
        display: "flex",
        flexDirection: "row",
        justifyContent: "space-evenly",
        flexWrap: "wrap"
    }

    const headerStyle = {
        width: "100%",
        backgroundColor: "white",
        position: "fixed",
        paddingLeft: "15px",
        paddingRight: "15px",
        zIndex: "10"
    }

    const imageStyle = {
        height: "40px"
    }

    return (
        <header style={headerStyle}>
            <nav className="navbar" style={navStyle}>
                <a href="#1stSect">
                    <img src="http://farm1.staticflickr.com/783/39077341920_fefc67a2b6_b.jpg" style={imageStyle} alt="The person who created this awesome page" />
                </a>
                <a href="#2ndSect" style={aStyle}>Portfolio</a>
                <a href="#3rdSect" style={aStyle}>About</a>
                <a href="#4thSect" style={aStyle}>Contact Me</a> 
		    </nav>             
	    </header>         
    )
}

export default header