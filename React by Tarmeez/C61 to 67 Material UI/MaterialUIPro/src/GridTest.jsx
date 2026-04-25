import Box from '@mui/material/Box';
import Paper from '@mui/material/Paper';
import Grid from '@mui/material/Grid';


export default function GridTest() {
  return (
    <Box sx={{ flexGrow: 1 }}>
      <Grid container spacing={2}>
        <Grid size={8}>
          size=8
        </Grid>
        <Grid size={4}>
          size=4
        </Grid>
        <Grid size={4}>
          size=4
        </Grid>
        <Grid size={8}>
          size=8
        </Grid>
      </Grid>
    </Box>
  );
}
