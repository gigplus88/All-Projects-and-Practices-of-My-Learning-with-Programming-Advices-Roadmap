import Stack from "@mui/material/Stack";
import Button from "@mui/material/Button";
import Avatar from '@mui/material/Avatar';
import Box from '@mui/material/Box';
import Slider from '@mui/material/Slider';
import Container from '@mui/material/Container';


export default function BasicButtons() {
  return (
      <Container maxWidth="lg">
        <Stack spacing={2} direction="row" style={{ background:"yellow" }}>
            <Button
                color="primary"
                variant="contained"
                onClick={() => {
                alert("clicked");
                }}
                size="large"
            >
                Text
            </Button>
            <Button variant="contained"color="secondary" >Contained</Button>
            <Button variant="outlined">Outlined</Button>

                <Box sx={{ width: 300 }}>
                    <Slider
                        size="small"
                        defaultValue={70}
                        aria-label="Small"
                        valueLabelDisplay="auto"
                    />
                    <Slider defaultValue={50} aria-label="Default" valueLabelDisplay="auto" />
                </Box>

               
                <Avatar alt="Cindy Baker" src="/static/images/avatar/3.jpg" />
        </Stack>
      </Container>
   

    
  );
}
