import React from "react"
import "./Project.css"
import IndividualProject from "./IndividualProject/IndividualProject"

const project = (props) => {
    const projectComponents = props.dataArr.map((project, index) => {
        return <IndividualProject url={project.url}
                        title={project.title}
                        imageURL={project.imageURL}
                        data={project.data} 
                        key={index}
                        alt={project.alt}/>
    })

    return (
        <div className="PortfolioBackground" id="2ndSect">
            {projectComponents}
		</div>
    )
}

export default project