import Paper from "@mui/material/Paper";
import Stack from "@mui/material/Stack";
import Collapse from "@mui/material/Collapse";
import Container from "@mui/material/Container";

import Accordion from "@mui/material/Accordion";
import AccordionSummary from "@mui/material/AccordionSummary";
import AccordionDetails from "@mui/material/AccordionDetails";
import Typography from "@mui/material/Typography";
import ExpandMoreIcon from "@mui/icons-material/ExpandMore";
import Switch from "@mui/material/Switch";
import { useState } from "react";

const label = { inputProps: { "aria-label": "Switch demo" } };



export default function Test() {
  const [checked, setChecked] = useState(true);


  return (
    <Container maxWidth="sm" style={{ marginTop: "60px" }}>
      <>
        <Accordion defaultExpanded>
          <AccordionSummary
            expandIcon={<ExpandMoreIcon />}
            aria-controls="panel1-content"
            id="panel1-header"
          >
            <Typography component="span">Expanded by default</Typography>
          </AccordionSummary>
          <AccordionDetails>
            <Typography>
              Lorem ipsum dolor sit amet, consectetur adipiscing elit.
              Suspendisse malesuada lacus ex, sit amet blandit leo lobortis
              eget.
            </Typography>
          </AccordionDetails>
        </Accordion>

        <Accordion defaultExpanded>
          <AccordionSummary
            expandIcon={<ExpandMoreIcon />}
            aria-controls="panel1-content"
            id="panel1-header"
          >
            <Typography component="span">Expanded by default</Typography>
          </AccordionSummary>
          <AccordionDetails>
            <Typography>
              <Switch
                {...label}
                defaultChecked
                checked={checked}
                onClick={() => {
                  setChecked((prev) => !prev);
                }}
              />
            </Typography>
          </AccordionDetails>
        </Accordion>

        <Collapse in={checked} collapsedSize={40} > 
          <div
            style={{
              background: "green",
              height: "100px" /*, height: checked ? "90px" : "60px" */,
            }}
          >
            <h2>Hello world</h2>
          </div>
        </Collapse>
      </>
    </Container>
  );
}
